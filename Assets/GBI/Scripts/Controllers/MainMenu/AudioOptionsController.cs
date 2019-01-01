using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class AudioOptionsController
    {
        private static AudioOptionsController instance = null;
        public static AudioOptionsController Instance
        {
            get
            {
                    if (instance == null)
                        instance = new AudioOptionsController();
                    return instance;
            }
        }

        internal AudioOptionsModel _audioOptions = AudioOptionsModel.Instance;


        public void ReadDataFromFile()
        {
            //вызов метода чтения из файла из класса чтения/записи
        }

        public void WriteDataToFile()
        {
            //вызов метода записи в файл из класса чтения/записи
        }
    }
}

