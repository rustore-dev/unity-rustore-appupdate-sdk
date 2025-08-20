using RuStore.AppUpdate;
using RuStore.AppUpdateExample.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RuStore.AppUpdateExample {

    public class AppUpdateExample : MonoBehaviour, IInstallStateUpdateListener {

        [SerializeField]
        private Image _updateLoadingBar;

        [SerializeField]
        private MessageBox _messageBox;

        private void Awake() {
            RuStoreAppUpdateManager.Instance.Init();
        }

        public void GetAppUpdateInfo() {
            RuStoreAppUpdateManager.Instance.GetAppUpdateInfo(
                onFailure: OnAppUpdateError,
                onSuccess: OnAppUodateInfoReceived);
        }

        public void StartImmediateUpdate() {
            RuStoreAppUpdateManager.Instance.RegisterListener(this);
            RuStoreAppUpdateManager.Instance.StartUpdateFlow(UpdateType.IMMEDIATE, OnAppUpdateError,
                (result) => {
                    Debug.LogFormat("Update flow result -> {0}", result);
                    if (result == UpdateFlowResult.RESULT_CANCELED || result == UpdateFlowResult.RESULT_ACTIVITY_NOT_FOUND) {
                        RuStoreAppUpdateManager.Instance.UnregisterListener(this);
                    }
                });

        }

        public void StartFlexibleUpdate() {
            RuStoreAppUpdateManager.Instance.RegisterListener(this);
            RuStoreAppUpdateManager.Instance.StartUpdateFlow(UpdateType.FLEXIBLE, OnAppUpdateError,
                (result) => {
                    Debug.LogFormat("Update flow result -> {0}", result);
                    if (result == UpdateFlowResult.RESULT_CANCELED) {
                        RuStoreAppUpdateManager.Instance.UnregisterListener(this);
                    }
                });
        }
        public void StartSilentUpdate() {
            RuStoreAppUpdateManager.Instance.RegisterListener(this);
            RuStoreAppUpdateManager.Instance.StartUpdateFlow(UpdateType.SILENT, OnAppUpdateError,
                (result) => {
                    Debug.LogFormat("Update flow result -> {0}", result);
                });
        }

        void OnAppUpdateError(RuStoreError error) {
            ShowMessage("Error", string.Format("{0} : {1}", error.name, error.description));
        }

        public void FinishSilentUpdate() {
            RuStoreAppUpdateManager.Instance.CompleteUpdate(UpdateType.SILENT, OnAppUpdateError);
        }
        public void FinishFlexibleUpdate() {
            RuStoreAppUpdateManager.Instance.CompleteUpdate(UpdateType.FLEXIBLE, OnAppUpdateError);
        }

        public void ShowUpdateProgress(float progress) {
            var scale = _updateLoadingBar.transform.localScale;
            scale.x = progress;
            _updateLoadingBar.transform.localScale = scale;
        }

        void OnAppUodateInfoReceived(AppUpdateInfo info) {

            var message = "Обновление недоступно";

            switch (info.updateAvailability) {
                case AppUpdateInfo.UpdateAvailability.UPDATE_AVAILABLE:
                    message = string.Format("Доступно обновление v{0}", info.availableVersionCode);
                    break;
                case AppUpdateInfo.UpdateAvailability.DEVELOPER_TRIGGERED_UPDATE_IN_PROGRESS:
                    message = "Обновление в процессе";
                    break;
                default:
                    message = "Обновление недоступно";
                    break;
            }

            ShowMessage("Обновление", message);

            var isImmediateUpdateAllowed = RuStoreAppUpdateManager.Instance.IsImmediateUpdateAllowed();
            Debug.LogFormat("isImmediateUpdateAllowed: {0}", isImmediateUpdateAllowed);
        }

        void IInstallStateUpdateListener.OnStateUpdated(InstallState state) {
            if (state.installStatus == InstallState.InstallStatus.DOWNLOADED) {
                ShowUpdateProgress(progress: 1f);
            } else if (state.installStatus == InstallState.InstallStatus.FAILED) {
                RuStoreAppUpdateManager.Instance.UnregisterListener(this);
                ShowUpdateProgress(progress: 0f);
            } else if (state.installStatus == InstallState.InstallStatus.DOWNLOADING) {
                ShowUpdateProgress(progress: (float)state.bytesDownloaded / (float)state.totalBytesToDownload);
            }
        }
        void ShowMessage(string title, string message, Action onClose = null) {
            _messageBox.Show(
                title: title,
                message: message,
                onClose: onClose);
        }

        void OnError(RuStoreError error) {
            Debug.LogErrorFormat("{0}: {1}", error.name, error.description);
        }
    }
}
