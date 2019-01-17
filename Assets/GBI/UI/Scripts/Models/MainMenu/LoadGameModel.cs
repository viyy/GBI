using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Класс модели меню загрузки сохраненной игры
    /// </summary>
    internal class LoadGameModel
    {
        /// <summary>
        /// Поле, хранящее путь к источнику данных о сохранениях
        /// </summary>
        internal string pathToSaveData;

        /// <summary>
        /// Поле, хранящее ссылку на стэк сохраненных игр в формате SaveData
        /// </summary>
        internal Stack<SaveData> saveDataStack;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса LoadGameModel (реализация Singletone)
        /// </summary>
        private static LoadGameModel _instance = null;

        /// <summary>
        /// Свойство для доступа к ссылке на экземпляр класса LoadGameModel (реализация Singletone)
        /// </summary>
        internal static LoadGameModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LoadGameModel();
                return _instance;
            }
        }

        /// <summary>
        /// Конструктор класса LoadGameModel
        /// </summary>
        private LoadGameModel()
        {
            saveDataStack = new Stack<SaveData>();
        }

        /// <summary>
        /// Метод получения текуших данных о сохраненных играх
        /// </summary>
        /// <param name="loader">Ссылка на загрузчик данных, реализующий интерфейс IDataLoader</param>
        /// <returns></returns>
        internal Stack<SaveData> GetData(IDataLoader<SaveData> loader)
        {
            if(saveDataStack == null)
                saveDataStack = loader?.LoadDataToStack(pathToSaveData);
            return saveDataStack;
        }
    }
}