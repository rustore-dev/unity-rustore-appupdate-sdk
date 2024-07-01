using UnityEngine;
using System;
using RuStore.Internal;
using RuStore.AppUpdate.Internal;
using System.Collections.Generic;

namespace RuStore.AppUpdate {

    public class RuStoreAppUpdateManager {

        public static string PluginVersion = "3.0.0";

        private static RuStoreAppUpdateManager _instance;
        private static bool _isInstanceInitialized;

        private bool _isInitialized;
        public bool IsInitialized => _isInitialized;
        private AndroidJavaObject _managerWrapper;

        private Dictionary<IInstallStateUpdateListener, InstallStateUpdateListener> _stateListeners = new Dictionary<IInstallStateUpdateListener, InstallStateUpdateListener>();

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

        public void GetAppUpdateInfo(Action<RuStoreError> onFailure, Action<AppUpdateInfo> onSuccess) {
            if (!IsPlatformSupported(onFailure)) {
                return;
            }

            var listener = new AppUpdateInfoResponseListener(onFailure, onSuccess);
            _managerWrapper.Call("getAppUpdateInfo", listener);
        }

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

        public bool IsImmediateUpdateAllowed() {
            if (!IsPlatformSupported(null)) {
                return false;
            }

            return _managerWrapper.Call<bool>("isImmediateUpdateAllowed");
        }

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
