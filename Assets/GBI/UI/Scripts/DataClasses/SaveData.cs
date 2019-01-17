using System;

namespace Geekbrains
{
    /// <summary>
    /// Класс сохраненной игры
    /// </summary>
    internal class SaveData
    {
        /// <summary>
        /// Поле, хранящее идентификатор сохраненной игры
        /// </summary>
        internal readonly int id;

        /// <summary>
        /// Поле, хранящее наименование локации
        /// </summary>
        internal readonly string locationKey;

        /// <summary>
        /// Поле, хранящее имя игрока
        /// </summary>
        internal readonly string playerName;

        /// <summary>
        /// Поле, хранящее время сохранения игры
        /// </summary>
        internal readonly DateTime savingDateTime;

        /// <summary>
        /// Поле, хранящее путь к скриншоту сохраненной игры
        /// </summary>
        internal readonly string pathToImage;

        /// <summary>
        /// Конструктор класса SaveData
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="locationKey">Наименование локации</param>
        /// <param name="playerName">Имя игрока</param>
        /// <param name="savingDateTime">Время сохранения игры</param>
        /// <param name="pathToImage">Путь к скриншоту сохраняемой игры</param>
        internal SaveData(int id, string locationKey, string playerName, DateTime savingDateTime, string pathToImage)
        {
            this.id = id;
            this.locationKey = locationKey;
            this.playerName = playerName;
            this.savingDateTime = savingDateTime;
            this.pathToImage = pathToImage;
        }
    }
}