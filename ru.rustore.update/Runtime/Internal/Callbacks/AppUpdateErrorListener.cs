using RuStore.Internal;
using System;
using UnityEngine;

namespace RuStore.AppUpdate.Internal {

    public class AppUpdateErrorListener : ErrorListener {

        private static string javaClassName = "ru.rustore.unitysdk.appupdate.callbacks.CompleteUpdateListener";

        public AppUpdateErrorListener(Action<RuStoreError> onFailure) : base(javaClassName, onFailure) {
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
