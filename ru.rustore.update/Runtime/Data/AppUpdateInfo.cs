namespace RuStore.AppUpdate {

    /// <summary>
    /// Информция о доступном обновлении.
    /// </summary>
    public class AppUpdateInfo {

        /// <summary>
        /// Доступность обновления.
        /// </summary>
        public enum UpdateAvailability {

            /// <summary>
            /// Значение по умолчанию.
            /// </summary>
            UNKNOWN,

            /// <summary>
            /// Обновление не требуется.
            /// </summary>
            UPDATE_NOT_AVAILABLE,

            /// <summary>
            /// Обновление требуется загрузить или обновление уже загружено на устройство пользователя.
            /// </summary>
            UPDATE_AVAILABLE,

            /// <summary>
            /// Обновление уже скачивается или установка уже запущена.
            /// </summary>
            DEVELOPER_TRIGGERED_UPDATE_IN_PROGRESS,
        }

        /// <summary>
        /// Статус установки обновления, если пользователь уже устанавливает обновление в текущий момент времени.
        /// </summary>
        public enum InstallStatus {

            /// <summary>
            /// Значение по умолчанию.
            /// </summary>
            UNKNOWN,

            /// <summary>
            /// Скачано.
            /// </summary>
            DOWNLOADED,

            /// <summary>
            /// Скачивается.
            /// </summary>
            DOWNLOADING,

            /// <summary>
            /// Ошибка.
            /// </summary>
            FAILED,

            /// <summary>
            /// Установка.
            /// </summary>
            INSTALLING,

            /// <summary>
            /// В ожидании.
            /// </summary>
            PENDING,
        }

        /// <summary>
        /// Доступность обновления.
        /// </summary>
        public UpdateAvailability updateAvailability;

        /// <summary>
        /// Статус установки обновления, если пользователь уже устанавливает обновление в текущий момент времени.
        /// </summary>
        public InstallStatus installStatus;

        /// <summary>
        /// Код версии обновления.
        /// </summary>
        public long availableVersionCode;
    }
}
