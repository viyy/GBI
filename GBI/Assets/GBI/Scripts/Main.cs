using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class Main : MonoBehaviour, IRegistrator<IUpdatable>, IRegistrator<IFixedUpdatable>, IEventDispatcher
    {
        public static Main Instance { get; private set; }

        private List<IUpdatable>      _updatebles;
        private List<IFixedUpdatable> _fixedUpdatebles;
        private EventDispatcher       _eventDispatcher;

        public SkillsContainerController SkillsContainerController { get; private set; }
        public PauseController           PauseController           { get; private set; }
        public LocaleController          LocaleController          { get; private set; }
        public InputController           InputController           { get; private set; }
        public SettingsController        SettingsController        { get; private set; }
        public InventoryController       InventoryController       { get; private set; }

        private void Awake()
        {
            if ( Instance ) {
                DestroyImmediate(gameObject);
            } else {
                Construct();
            }
        }

        private void Construct()
        {
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
            new CharacteristicContainerController(new CharacteristicContainerModel());
        }

        public void Update()
        {
            var deltaTime = Time.deltaTime;
            _updatebles.ForEach(updatable => updatable.OnUpdate(deltaTime));
        }

        private void FixedUpdate()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            _fixedUpdatebles.ForEach(updatable => updatable.OnFixedUpdate(fixedDeltaTime));
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
    }
}