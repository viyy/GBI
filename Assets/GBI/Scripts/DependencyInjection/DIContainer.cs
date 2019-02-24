using System;
using System.Collections.Generic;
using System.Linq;

namespace Geekbrains
{
    /// <summary>
    /// Простейший DI контейнер
    /// </summary>
    public  class DIContainer
    {
        /// <summary>
        /// Хранилище ссылок по типу
        /// </summary>
        private Dictionary<Type, object> _container;
        
        public DIContainer()
        {
            _container = new Dictionary<Type, object>();
            
            RegisterType(this);
        }

        /// <summary>
        /// Конструктор с инъекцией в объект
        /// </summary>
        /// <param name="obj"></param>
        public DIContainer(object obj) : base()
        {
            Inject(obj);
        }

        /// <summary>
        /// Метод получения зарегестрированного типа
        /// </summary>
        /// <typeparam name="T">зарегестрированный тип</typeparam>
        /// <returns>Объект из хранилища или null</returns>
        public T Resolve<T>()
            where T : class
        {
            _container.TryGetValue(typeof(T), out var obj);

            return obj as T;
        }

        /// <summary>
        /// Метод получения зарегестрированного типа
        /// </summary>
        /// <param name="type">зарегестрированный тип</param>
        /// <returns>Объект из хранилища или null</returns>
        public object Resolve(Type type)
        {
            _container.TryGetValue(type, out var obj);

            return obj;
        }

        /// <summary>
        /// Метод инъекции. Выбирает все поля, находит те, которые помечены атрибутом Inject и заполняет их 
        /// </summary>
        /// <param name="obj">Объект для парсинга</param>
        public void Inject(object obj)
        {

            var type = obj.GetType();
            
            var fieldInfos = type.GetFields();
            
            foreach (var member in fieldInfos)
            {
                var attrs = member.GetCustomAttributes(typeof(InjectAttribute), true);
                if (!attrs.Any())
                    return;

                // ReSharper disable once PossibleMistakenCallToGetType.2
                var valueObj = Resolve(member.FieldType);
               
                member.SetValue(obj, valueObj);
            }
        }

        /// <summary>
        /// Регистрация типа
        /// </summary>
        /// <param name="obj">Объект, который должен быть зарегестрирован</param>
        /// <typeparam name="TType">Тип, по которому будет регистрироваться объект</typeparam>
        /// <typeparam name="TObject">Тип регестрируемого объекта</typeparam>
        public void RegisterType<TType, TObject>(TObject obj)
        {
            RegisterType(typeof(TType), obj);
        }
        
        /// <summary>
        /// Регистрация типа
        /// </summary>
        /// <param name="obj">Объект, который должен быть зарегестрирован</param>
        /// <typeparam name="TObject">Тип регестрируемого объекта</typeparam>
        public void RegisterType<TObject>(TObject obj)
        {
            RegisterType( obj.GetType(), obj );
        }

        /// <summary>
        /// Регистрация типа
        /// </summary>
        /// <param name="type">Тип регестрируемого объекта</param>
        /// <param name="obj">Объект, который должен быть зарегестрирован</param>
        /// <typeparam name="TObject">Тип регестрируемого объекта</typeparam>
        public void RegisterType<TObject>(Type type, TObject obj)
        {
            if (_container.ContainsKey(type))
            {
                LogWrapper.Info("Type already in container");
            }
            else
            {
                _container.Add(type, obj);
            }
        }

        /// <summary>
        /// Удаление объекта из хранилища
        /// </summary>
        /// <typeparam name="TType">Тип, по которому будет удаляться объект</typeparam>
        public void Realize<TType>()
        {
            Realize(typeof(TType));
        }

        /// <summary>
        /// Удаление объекта из хранилища
        /// </summary>
        /// <param name="type">Тип, по которому будет удаляться объект</param>
        public void Realize(Type type)
        {
            if (_container.ContainsKey(type))
            {
                _container.Remove(type);
            }
            else
            {
                LogWrapper.Info("Type isn't in container");
            }
        }
    }
}