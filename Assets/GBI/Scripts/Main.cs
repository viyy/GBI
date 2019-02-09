using System;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Главная точка входа всей игры
    /// </summary>
    /// <see cref="Geekbrains.IEventDispatcher"/>
    /// <br/>
    /// <see cref="IRegistrator{T}"/>
    public class Main : MonoBehaviour, IRegistrator<IUpdatable>, IRegistrator<IFixedUpdatable>, IEventDispatcher
    {
        /// <summary>
        /// Singleton для основного класса
        /// </summary>
        public static Main Instance { get; private set; }

        /// <summary>
        /// Список объектов, вызываемых в каждом кадре
        /// </summary>
        private List<IUpdatable> _updatebles;

        /// <summary>
        /// Список объектов, вызываемых при каждом шаге физического движка
        /// </summary>
        private List<IFixedUpdatable> _fixedUpdatebles;

        /// <summary>
        /// Объект диспатчера событий для главного класса
        /// </summary>
        private EventDispatcher _eventDispatcher;

        /// <summary>
        /// Основная точка доступа к контроллеру скиллов
        /// </summary>
        public SkillsContainerController SkillsContainerController { get; private set; }

        /// <summary>
        /// Основная точка доступа к контроллеру паузы
        /// </summary>
        public PauseController PauseController { get; private set; }

        /// <summary>
        /// Основная точка доступа к контроллеру локали
        /// </summary>
        public LocaleController LocaleController { get; private set; }

        /// <summary>
        /// Основная точка доступа к контроллеру ввода
        /// </summary>
        public InputController InputController { get; private set; }

        /// <summary>
        /// Основная точка доступа к контроллеру настроек
        /// </summary>
        public SettingsController SettingsController { get; private set; }

        /// <summary>
        /// Основная точка доступа к контроллеру инвентаря
        /// </summary>
        public InventoryController InventoryController { get; private set; }

        /// <summary>
        /// Основная точка доступа к контроллеру характеристик персонажа
        /// </summary>
        public CharacteristicContainerController CharacteristicContainerController { get; private set; }

        public PlayerController PlayerController { get; set; }

        /// <summary>
        /// Метод, запускающий конструктор
        /// </summary>
        private void Awake()
        {
            if ( Instance ) {
                DestroyImmediate(gameObject);
            } else {
                Construct();
            }
        }

        /// <summary>
        /// Конструктор, создающий все необходимые объекты для главного класса
        /// </summary>
        private void Construct()
        {
            Instance = this;

            _eventDispatcher = new EventDispatcher();
            _updatebles      = new List<IUpdatable>();
            _fixedUpdatebles = new List<IFixedUpdatable>();

            // Можно перенести в singleton c инициализацией с задержкой
            SkillsContainerController = new SkillsContainerController(new SkillsContainerModel());
            PauseController           = new PauseController(new PauseModel());
            LocaleController          = new LocaleController(new LocaleModel());
            InputController           = new InputController(new BaseModel());
            SettingsController        = new SettingsController(new SettingsModel());
            InventoryController       = new InventoryController(new InventoryModel());
            CharacteristicContainerController =
                new CharacteristicContainerController(new CharacteristicContainerModel());

            CreatePlayer();

            Register(InputController);
            Register(PlayerController);
        }

        private void CreatePlayer()
        {
            var model = new PlayerModel();
            var prefab = Resources.Load<GameObject>("Player");
            prefab.name = "Player";
            var instance = Instantiate(prefab);
            var view = instance.GetComponent<PlayerView>();
            PlayerController = new PlayerController(model, view);
        }

        public void Update()
        {
            var deltaTime = Time.deltaTime;
            for ( var i = 0; i < _updatebles.Count; i++ ) {
                _updatebles[i].OnUpdate(deltaTime);
            }
        }

        
        private void FixedUpdate()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            for ( var i = 0; i < _fixedUpdatebles.Count; i++ ) {
                _fixedUpdatebles[i].OnFixedUpdate(fixedDeltaTime);
            }
        }

        public void Register(IUpdatable record)
        {
            _updatebles.Add(record);
        }

        public void Unregister(IUpdatable record)
        {
            if ( _updatebles.Contains(record) ) {
                _updatebles.Remove(record);
            }
        }

        public void Register(IFixedUpdatable record)
        {
            _fixedUpdatebles.Add(record);
        }

        public void Unregister(IFixedUpdatable record)
        {
            if ( _fixedUpdatebles.Contains(record) ) {
                _fixedUpdatebles.Remove(record);
            }
        }

        public void DispatchEvent<T>(T eventArgs)
            where T : BaseEvent
        {
            _eventDispatcher.DispatchEvent(eventArgs);
        }

        public void AddEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent
        {
            _eventDispatcher.AddEventListener(listener);
        }

        public void RemoveEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent
        {
            _eventDispatcher.RemoveEventListener(listener);
        }

        public bool HasEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent
        {
            return _eventDispatcher.HasEventListener(listener);
        }
    }
}