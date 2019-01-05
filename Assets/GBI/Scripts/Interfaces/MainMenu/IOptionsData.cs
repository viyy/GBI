using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public interface IOptionsData<T>
    {
        List<OptionsParameter<T>> GetOptions();

        void ChangeParameter(string key, T parameterValue);
    }
}