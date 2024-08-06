namespace RuStore.AppUpdate {

    public class AppUpdateInfo {
        public enum UpdateAvailability {

            UNKNOWN,
            UPDATE_NOT_AVAILABLE,
            UPDATE_AVAILABLE,
            DEVELOPER_TRIGGERED_UPDATE_IN_PROGRESS,
        }

        public enum InstallStatus {

            UNKNOWN,
            DOWNLOADED,
            DOWNLOADING,
            FAILED,
            INSTALLING,
            PENDING,
        }

        public UpdateAvailability updateAvailability;
        public InstallStatus installStatus;
        public long availableVersionCode;
    }
}
