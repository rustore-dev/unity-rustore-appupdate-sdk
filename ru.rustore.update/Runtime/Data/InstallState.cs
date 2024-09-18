namespace RuStore.AppUpdate {

    public class InstallState {

        public enum InstallStatus {

            UNKNOWN,
            DOWNLOADED,
            DOWNLOADING,
            FAILED,
            INSTALLING,
            PENDING,
        }

        public enum InstallErrorCode {

            ERROR_UNKNOWN = 4001,
            ERROR_DOWNLOAD,
            ERROR_BLOCKED,
            ERROR_INVALID_APK,
            ERROR_CONFLICT,
            ERROR_STORAGE,
            ERROR_INCOMPATIBLE,
            ERROR_APP_NOT_OWNED,
            ERROR_INTERNAL_ERROR,
            ERROR_ABORTED,
            ERROR_APK_NOT_FOUND,
            ERROR_EXTERNAL_SOURCE_DENIED,
        }

        public long bytesDownloaded;
        public long totalBytesToDownload;
        public InstallStatus installStatus;
        public InstallErrorCode installErrorCode;
    }
}
