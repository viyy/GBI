using System;
using System.Collections.Generic;
using Geekbrains;
using UnityEngine;
using UnityEngine.Events;

namespace GBI.Scripts.Events
{
    public class EventManager : MonoBehaviour {

        private Dictionary <GameEventTypes, GameEvent> _eventDictionary;

        private static EventManager _eventManager;

        public static EventManager Instance
        {
            get
            {
                if (_eventManager) return _eventManager;
                _eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;

                if (!_eventManager)
                {
                    LogWrapper.Error("EventManager: There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    if (_eventManager != null) _eventManager.Init();
                    else
                    {
                        LogWrapper.Error("EventManager: Something REALLY GOING WRONG");
                    }
                }

                return _eventManager;
            }
        }

        private void Init ()
        {
            if (_eventDictionary == null)
            {
                _eventDictionary = new Dictionary<GameEventTypes, GameEvent>();
            }
        }

        public static void StartListening (GameEventTypes eventName, UnityAction<EventArgs> listener)
        {
            if (Instance._eventDictionary.TryGetValue (eventName, out var thisEvent))
            {
                thisEvent.AddListener (listener);
            } 
            else
            {
                thisEvent = new GameEvent();
                thisEvent.AddListener (listener);
                Instance._eventDictionary.Add (eventName, thisEvent);
            }
        }

        public static void StopListening (GameEventTypes eventName, UnityAction<EventArgs> listener)
        {
            if (_eventManager == null) return;
            if (Instance._eventDictionary.TryGetValue (eventName, out var thisEvent))
            {
                thisEvent.RemoveListener (listener);
            }
        }

        public static void TriggerEvent (GameEventTypes eventName, EventArgs eventArgs)
        {
            if (Instance._eventDictionary.TryGetValue (eventName, out var thisEvent))
            {
                thisEvent.Invoke(eventArgs);
            }
        }
    }
}