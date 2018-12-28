using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class OptionsParameter<T>
    {
        private string _key;

        private T _parameterValue;

        internal string GetKey => _key;

        public T GetValue => _parameterValue;

        public OptionsParameter(string key, T parameterValue)
        {
            _key = key;
            _parameterValue = parameterValue;
        }

        internal void ChangeKey(string newKey)
        {
            _key = newKey;
        }

        public void ChangeValue(T newValue)
        {
            _parameterValue = newValue;
        }
    }
}