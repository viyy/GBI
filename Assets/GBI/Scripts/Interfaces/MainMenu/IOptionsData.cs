using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public interface IOptionsData<T>
    {
        List<object> GetOptions();

        void ChangeParameter(string key, T parameterValue);
    }
}