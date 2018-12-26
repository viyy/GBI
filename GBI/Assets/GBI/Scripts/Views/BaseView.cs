using UnityEngine;

namespace Geekbrains
{
    public class BaseView<T> : MonoBehaviour, IRegistrator<T>
        where T : BaseModel
    {
        protected T _model;

        public void Register(T record)
        {
            _model = record;
        }

        public void Unregister(T record)
        {
            Debug.Log("Not supported");
        }
    }
}