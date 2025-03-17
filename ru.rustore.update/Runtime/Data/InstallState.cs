namespace RuStore.AppUpdate {

    /// <summary>
    /// Описывает текущее состояние установки обновления.
    /// </summary>
    public class InstallState {

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
        /// Код ошибки во время скачивания.
        /// </summary>
        public enum InstallErrorCode {

            /// <summary>
            /// Неизвестная ошибка.
            /// </summary>
            ERROR_UNKNOWN = 4001,

            /// <summary>
            /// Ошибка при скачивании.
            /// </summary>
            ERROR_DOWNLOAD,

            /// <summary>
            /// Установка заблокированна системой.
            /// </summary>
            ERROR_BLOCKED,

            /// <summary>
            /// Некорректный APK обновления.
            /// </summary>
            ERROR_INVALID_APK,

            /// <summary>
            /// Конфликт с текущей версией приложения.
            /// </summary>
            ERROR_CONFLICT,

            /// <summary>
            /// Недостаточно памяти на устройстве.
            /// </summary>
            ERROR_STORAGE,

            /// <summary>
            /// Несовместимо с устройством.
            /// </summary>
            ERROR_INCOMPATIBLE,

            /// <summary>
            /// Приложение не куплено.
            /// </summary>
            ERROR_APP_NOT_OWNED,

            /// <summary>
            /// Внутренняя ошибка.
            /// </summary>
            ERROR_INTERNAL_ERROR,

            /// <summary>
            /// Пользователь отказался от установки обновления.
            /// </summary>
            ERROR_ABORTED,

            /// <summary>
            /// APK для запуска установки не найден.
            /// </summary>
            ERROR_APK_NOT_FOUND,

            /// <summary>
            /// Запуск обновления запрещён. Например, в первом методе вернулся ответ о том, что обновление недоступно, но пользователь вызывает второй метод.
            /// </summary>
            ERROR_EXTERNAL_SOURCE_DENIED,

            /// <summary>
            /// Ошибка отправки intent на открытие активити.
            /// </summary>
            ERROR_ACTIVITY_SEND_INTENT = 9901,
            
            /// <summary>
            /// Неизвестная ошибка отрытия активити.
            /// </summary>
            ERROR_ACTIVITY_UNKNOWN
        }

        /// <summary>
        /// Количество загруженных байт.
        /// </summary>
        public long bytesDownloaded;

        /// <summary>
        /// Общее количество байт, которое необходимо скачать.
        /// </summary>
        public long totalBytesToDownload;

        /// <summary>
        /// Статус установки обновления, если пользователь уже устанавливает обновление в текущий момент времени.
        /// </summary>
        public InstallStatus installStatus;

        /// <summary>
        /// Код ошибки во время скачивания.
        /// </summary>
        public InstallErrorCode installErrorCode;
    }
}
