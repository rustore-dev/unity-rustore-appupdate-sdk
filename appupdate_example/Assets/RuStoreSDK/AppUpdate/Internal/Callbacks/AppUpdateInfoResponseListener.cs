using RuStore.Internal;
using System;
using UnityEngine;

namespace RuStore.AppUpdate.Internal {

    public class AppUpdateInfoResponseListener : ResponseListener<AppUpdateInfo> {

            private const string javaClassName = "ru.rustore.unitysdk.appupdate.callbacks.AppUpdateInfoResponseListener";

        public AppUpdateInfoResponseListener(Action<RuStoreError> onFailure, Action<AppUpdateInfo> onSuccess) : base(javaClassName, onFailure, onSuccess) {
        }

        protected override AppUpdateInfo ConvertResponse(AndroidJavaObject responseObject) {
            var response = new AppUpdateInfo() {
                updateAvailability = (AppUpdateInfo.UpdateAvailability)responseObject.Get<int>("updateAvailability"),
                installStatus = (AppUpdateInfo.InstallStatus)responseObject.Get<int>("installStatus"),
                availableVersionCode = responseObject.Get<long>("availableVersionCode")
            };

            return response;
        }

        protected override RuStoreError ConvertError(AndroidJavaObject errorObject) {
            var error = base.ConvertError(errorObject);

            if (error.name == "RuStoreInstallException") {
                var errorCode = (InstallState.InstallErrorCode)errorObject.Get<int>("code");
                error.description = errorCode.ToString();
            }

            return error;
        }
    }
}
