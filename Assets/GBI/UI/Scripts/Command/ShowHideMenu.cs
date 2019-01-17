namespace Geekbrains
{
    /// <summary>
    /// Класс команды на отображение меню
    /// </summary>
    internal class ShowHideMenu : IMenuCommand
    {
        /// <summary>
        /// Поле, хранящее ссылку на контроллер меню, реализующий интерфейс IMenuController
        /// </summary>
        private IMenuController _menuController;

        /// <summary>
        /// Конструктор класса ShowHideMenu
        /// </summary>
        /// <param name="menuController">Ссылка на экземпляр контроллера меню</param>
        internal ShowHideMenu(IMenuController menuController)
        {
            _menuController = menuController;
        }

        /// <summary>
        /// Метод открытия меню
        /// </summary>
        public void Enable()
        {
            _menuController.Show();
        }

        /// <summary>
        /// Метод закрытия меню
        /// </summary>
        public void Disable()
        {
            _menuController.Hide();
        }
    }
}