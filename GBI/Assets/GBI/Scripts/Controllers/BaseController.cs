using UnityEngine;

namespace Geekbrains
{
    public class BaseController<T> : IRegistrator<T>
        where T : BaseModel
    {
        protected T _model;

        public BaseController() {}

        public BaseController(T model)
        {
            Register(model);
        }

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