using System;
using UnityEngine;

namespace RuStore.AppUpdate.Internal {


    public class InstallStateUpdateListener : AndroidJavaProxy {

        protected const string ClassName = "ru.rustore.sdk.appupdate.listener.InstallStateUpdateListener";

        protected IInstallStateUpdateListener _listener;

        public InstallStateUpdateListener(IInstallStateUpdateListener listener) : base(ClassName) {
            _listener = listener;
        }

        public void onStateUpdated(AndroidJavaObject stateObject) {
            var state = new InstallState() {
                bytesDownloaded = stateObject.Get<long>("bytesDownloaded"),
                totalBytesToDownload = stateObject.Get<long>("totalBytesToDownload"), 
                installErrorCode = (InstallState.InstallErrorCode)stateObject.Get<int>("installErrorCode"),
                installStatus = (InstallState.InstallStatus)stateObject.Get<int>("installStatus"),
            };

            _listener?.OnStateUpdated(state);
        }
    }
}
