using System.Collections.Generic;

namespace Geekbrains {
    public class LoadGameModel
    {
        internal string pathToSaveData;

        internal Stack<SaveData> saveDataStack;

        private static LoadGameModel instance = null;

        internal static LoadGameModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoadGameModel();
                return instance;
            }
        }

        private LoadGameModel()
        {
            saveDataStack = new Stack<SaveData>();
        }

        internal Stack<SaveData> GetData(IDataLoader<SaveData> loader)
        {
            return saveDataStack = loader.LoadDataToStack(pathToSaveData);
        }
    }
}