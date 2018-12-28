using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public interface IOptionsData<T>
    {
        void ReadDataFromFile();

        void WriteDataToFile();

        List<object> GetOptions();

        void ChangeParameter(string key, T parameterValue);
    }
}