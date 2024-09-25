package ru.rustore.unitysdk.appupdate;

import ru.rustore.sdk.appupdate.listener.InstallStateUpdateListener
import ru.rustore.sdk.appupdate.manager.RuStoreAppUpdateManager
import ru.rustore.sdk.appupdate.manager.factory.RuStoreAppUpdateManagerFactory
import ru.rustore.sdk.appupdate.model.AppUpdateInfo
import ru.rustore.sdk.appupdate.model.AppUpdateOptions
import ru.rustore.sdk.appupdate.model.AppUpdateType
import ru.rustore.unitysdk.appupdate.callbacks.AppUpdateInfoResponseListener
import ru.rustore.unitysdk.appupdate.callbacks.CompleteUpdateListener
import ru.rustore.unitysdk.appupdate.callbacks.UpdateFlowResultListener
import ru.rustore.unitysdk.core.PlayerProvider

object RuStoreUnityAppUpdateManager {

    private lateinit var updateManager: RuStoreAppUpdateManager
    private var appUpdateInfo: AppUpdateInfo? = null
    private var isInitialized:Boolean = false
    
    fun init(metricType: String) {
        updateManager = RuStoreAppUpdateManagerFactory.create(
            context = PlayerProvider.getCurrentActivity().application,
            internalConfig = mapOf("type" to metricType)
        )
        isInitialized = true
    }

    fun getAppUpdateInfo(listener: AppUpdateInfoResponseListener) {
        updateManager.getAppUpdateInfo().addOnSuccessListener { result ->
            appUpdateInfo = result
            listener.OnSuccess(result)
        }.addOnFailureListener {
            throwable -> listener.OnFailure(throwable)
        }
    }

    fun isImmediateUpdateAllowed() : Boolean {
        appUpdateInfo?.let {
            return it.isUpdateTypeAllowed(AppUpdateType.IMMEDIATE)
        }
        return false;
    }

    fun registerListener(listener: InstallStateUpdateListener) {
        updateManager.registerListener(listener)
    }

    fun unregisterListener(listener: InstallStateUpdateListener) {
        updateManager.unregisterListener(listener)
    }

    fun startUpdateFlow(updateType: String, listener: UpdateFlowResultListener) {
        appUpdateInfo?.let {
            updateManager.startUpdateFlow(it, AppUpdateOptions.Builder().appUpdateType(getAppUpdateType(updateType)).build())
                .addOnSuccessListener {
                    resultCode -> listener.OnSuccess(resultCode)
                }
                .addOnFailureListener {
                    throwable -> listener.OnFailure(throwable)
                }
        }
    }

    private fun startUpdateFlow(listener: UpdateFlowResultListener, appUpdateOptions: AppUpdateOptions) {
        appUpdateInfo?.let {
            updateManager.startUpdateFlow(it, appUpdateOptions)
                .addOnSuccessListener {
                        resultCode -> listener.OnSuccess(resultCode)
                }
                .addOnFailureListener {
                        throwable -> listener.OnFailure(throwable)
                }
        }
    }

    fun completeUpdate(updateType: String, listener: CompleteUpdateListener) {
        val appUpdateOptions = AppUpdateOptions.Builder().appUpdateType(getAppUpdateType(updateType)).build()
        updateManager.completeUpdate(appUpdateOptions).addOnFailureListener {
            throwable -> listener.OnFailure(throwable)
        }
    }

    private fun getAppUpdateType(updateType: String) : Int {
        when (updateType) {
            "IMMEDIATE" -> return AppUpdateType.IMMEDIATE
            "FLEXIBLE" -> return AppUpdateType.FLEXIBLE
            "SILENT" -> return AppUpdateType.SILENT
        }
        return AppUpdateType.IMMEDIATE
    }
}
