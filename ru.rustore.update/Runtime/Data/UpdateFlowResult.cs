namespace RuStore.AppUpdate {

    /// <summary>
    /// Информация о результате обновления.
    /// </summary>
    public enum UpdateFlowResult {

        /// <summary>
        /// Обновление выполнено, код может не быть получен, т. к. приложение в момент обновления завершается.
        /// </summary>
        RESULT_OK = -1,

        /// <summary>
        /// Флоу прервано пользователем, или произошла ошибка.
        /// Предполагается, что при получении этого кода следует завершить работу приложения.
        /// </summary>
        RESULT_CANCELED = 0,

        /// <summary>
        /// RuStore не установлен, либо установлена версия, которая не поддерживает принудительное обновление (RuStore versionCode < 191).
        /// </summary>
        RESULT_ACTIVITY_NOT_FOUND = 2,
    }
}
