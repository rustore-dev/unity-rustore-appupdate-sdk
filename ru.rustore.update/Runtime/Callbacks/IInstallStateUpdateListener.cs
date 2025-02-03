
namespace RuStore.AppUpdate {

    /// <summary>
    /// Интерфейс слушателя колбэков установки обновления.
    /// </summary>
    public interface IInstallStateUpdateListener {

        /// <summary>
        /// Обработчик колбэка состояния обновления.
        /// </summary>
        /// <param name="state">Объект, описывающий текущий статус установки обновления.</param>
        public void OnStateUpdated(InstallState state);
    }
}
