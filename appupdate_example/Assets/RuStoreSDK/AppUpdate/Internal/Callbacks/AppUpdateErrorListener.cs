using RuStore.Internal;
using System;
using UnityEngine;

namespace RuStore.AppUpdate.Internal {

    public class AppUpdateErrorListener : ErrorListener {

        public AppUpdateErrorListener(Action<RuStoreError> onFailure) : base(onFailure) {
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
