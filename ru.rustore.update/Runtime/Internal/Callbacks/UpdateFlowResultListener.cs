using RuStore.Internal;
using System;
using UnityEngine;

namespace RuStore.AppUpdate.Internal {

    public class UpdateFlowResultListener : SimpleResponseListener<int> {

        private const string javaClassName = "ru.rustore.unitysdk.appupdate.callbacks.UpdateFlowResultListener";

        public UpdateFlowResultListener(Action<RuStoreError> onFailure, Action<int> onSuccess) : base(javaClassName, onFailure, onSuccess) {
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
