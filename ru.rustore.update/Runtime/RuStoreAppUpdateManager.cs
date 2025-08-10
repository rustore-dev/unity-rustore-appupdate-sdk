using UnityEngine;
using System;
using RuStore.Internal;
using RuStore.AppUpdate.Internal;
using System.Collections.Generic;

namespace RuStore.AppUpdate {

    /// <summary>
    /// Класс реализует API для трех способов обновлений.
    /// В настоящий момент поддерживаются: отложенное, тихое (без UI от RuStore) и принудительное обновление.
    /// </summary>
    public class RuStoreAppUpdateManager {

        /// <summary>
        /// Версия плагина.
        /// </summary>
        public static string PluginVersion = "10.0.0";

        private static RuStoreAppUpdateManager _instance;
        private static bool _isInstanceInitialized;

        private bool _isInitialized;

        /// <summary>
        /// Возвращает true, если синглтон был инициализирован, в противном случае — false.
        /// </summary>
        public bool IsInitialized => _isInitialized;
        private AndroidJavaObject _managerWrapper;

        private Dictionary<IInstallStateUpdateListener, InstallStateUpdateListener> _stateListeners = new Dictionary<IInstallStateUpdateListener, InstallStateUpdateListener>();

        /// <summary>
        /// Возвращает единственный экземпляр RuStoreAppUpdateManager (реализация паттерна Singleton).
        /// Если экземпляр еще не создан, создает его.
        /// </summary>
        public static RuStoreAppUpdateManager Instance {
            get {
                if (!_isInstanceInitialized) {
                    _isInstanceInitialized = true;
                    _instance = new RuStoreAppUpdateManager();
                }
                return _instance;
            }
        }

        private RuStoreAppUpdateManager() {
        }

        /// <summary>
        /// Выполняет инициализацию синглтона RuStoreAppUpdateManager.
        /// </summary>
        /// <returns>Возвращает true, если инициализация была успешно выполнена, в противном случае — false.</returns>
        public bool Init() {
            if (_isInitialized) {
                Debug.LogError("Error: RuStore AppUpdate Manager is already initialized");
                return false;
            }

            if (Application.platform != RuntimePlatform.Android) {
                return false;
            }

            CallbackHandler.InitInstance();

            using (var managerClass = new AndroidJavaClass("ru.rustore.unitysdk.appupdate.RuStoreUnityAppUpdateManager")) {
                _managerWrapper = managerClass.GetStatic<AndroidJavaObject>("INSTANCE");
            }

            _managerWrapper.Call("init", "unity");
            _isInitialized = true;

            return true;
        }

        /// <summary>
        /// Выполняет проверку наличия обновлений.
        /// </summary>
        /// <param name="onFailure">
        /// Действие, выполняемое в случае ошибки.
        /// Возвращает объект RuStore.RuStoreError с информацией об ошибке.
        /// </param>
        /// <param name="onSuccess">
        /// Действие, выполняемое при успешном завершении операции.
        /// Возвращает объект RuStore.AppUpdate.AppUpdateInfo с информцаией о необходимости обновления.
        /// </param>
        public void GetAppUpdateInfo(Action<RuStoreError> onFailure, Action<AppUpdateInfo> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new AppUpdateInfoResponseListener(onFailure, onSuccess);
            _managerWrapper.Call("getAppUpdateInfo", listener);
        }

        /// <summary>
        /// Выполняет регистрацию слушателя статуса скачивания обновления.
        /// </summary>
        /// <param name="listener">Объект класса, реализующего интерфейс RuStore.AppUpdate.Internal.IInstallStateUpdateListener.</param>
        public void RegisterListener(IInstallStateUpdateListener listener) {
            if (!IsPlatformSupported(null)) {
                return;
            }

            if (!_stateListeners.ContainsKey(listener)) {
                var stateListener = new InstallStateUpdateListener(listener);
                _stateListeners[listener] = stateListener;
                _managerWrapper.Call("registerListener", stateListener);
            }
        }

        /// <summary>
        /// Если необходимости в слушателе больше нет, воспользуйтесь методом удаления слушателя UnregisterListener(),
        /// передав в метод ранее зарегистрированный слушатель.
        /// </summary>
        /// <param name="listener">Объект класса, реализующего интерфейс RuStore.AppUpdate.Internal.IInstallStateUpdateListener.</param>
        public void UnregisterListener(IInstallStateUpdateListener listener) {
            if (!IsPlatformSupported(null)) {
                return;
            }

            if (_stateListeners.ContainsKey(listener)) {
                var stateListener = _stateListeners[listener];
                _managerWrapper.Call("unregisterListener", stateListener);
                _stateListeners.Remove(listener);
            }
        }

        /// <summary>
        /// Запускает процедуру скачивания обновления приложения.
        /// </summary>
        /// <param name="updateType">Тип процедуры скачивания обновления.</param>
        /// <param name="onFailure">
        /// Действие, выполняемое в случае ошибки.
        /// Возвращает объект RuStore.RuStoreError с информацией об ошибке.
        /// </param>
        /// <param name="onSuccess">
        /// Действие, выполняемое при успешном завершении операции.
        /// Возвращает объект RuStore.AppUpdate.RuStore.UpdateFlowResult с информацией о результате операции обновления.
        /// </param>
        public void StartUpdateFlow(UpdateType updateType, Action<RuStoreError> onFailure, Action<UpdateFlowResult> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new UpdateFlowResultListener(onFailure, 
                (result) => { 
                    onSuccess?.Invoke((UpdateFlowResult)result); 
                });

            _managerWrapper.Call("startUpdateFlow", updateType.ToString(), listener);
        }

        /// <summary>
        /// Выполняет проверку доступности принудительного обновления.
        /// </summary>
        /// <returns>Возвращает true, если принудительное обновление доступно, в противном случае — false.</returns>
        public bool IsImmediateUpdateAllowed() {
            if (!IsPlatformSupported(null)) {
                return false;
            }

            return _managerWrapper.Call<bool>("isImmediateUpdateAllowed");
        }

        /// <summary>
        /// Запускает процедуру установки обновления.
        /// В метод можно передавать только два типа завершения установки RuStore.AppUpdate.UpdateType.FLEXIBLE и RuStore.AppUpdate.UpdateType.SILENT.
        /// </summary>
        /// <param name="updateType">Тип процедуры завершения обновления.</param>
        /// <param name="onFailure">
        /// Действие, выполняемое в случае ошибки.
        /// Возвращает объект RuStore.RuStoreError с информацией об ошибке.
        /// </param>
        public void CompleteUpdate(UpdateType updateType, Action<RuStoreError> onFailure) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new AppUpdateErrorListener(onFailure);
            _managerWrapper.Call("completeUpdate", updateType.ToString(), listener);
        }

        private bool IsPlatformSupported(Action<RuStoreError> onFailure) {
            if (Application.platform != RuntimePlatform.Android) {
                onFailure?.Invoke(new RuStoreError() {
                    name = "RuStoreAppUpdateManager Error",
                    description = "Unsupported platform"
                });
                return false;
            }

            return true;
        }
    }
}
