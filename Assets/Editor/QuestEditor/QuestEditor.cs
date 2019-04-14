using DefaultNamespace;
using GBI.Scripts.Dto;
using GBI.Scripts.Storage;
using Geekbrains;
using Geekbrains.Skills;
using UnityEditor;
using UnityEngine;
using EG = UnityEditor.EditorGUILayout;

namespace Editor.QuestEditor
{
    public class QuestEditor : EditorWindow
    {
        [MenuItem("GBI/Quest Editor")]
        public static void ShowWindow()
        {
            _nextId = Saver.GetNextId();
            //Show existing window instance. If one doesn't exist, make one.
            GetWindow(typeof(QuestEditor));
            Debug.Log("Window Loaded.");
        }

        private static readonly IDevQuestSaver Saver = new XmlDevQuestStorage();
        
        private QuestDto _quest = new QuestDto();
        private static int _nextId;
        private int _ri = -1;
        
        private QuestMarkerDto _markerDto = new QuestMarkerDto{MapId = -1};
        
        private QuestTaskDto _task = new QuestTaskDto{Type = QuestTaskTypes.None};

        private int _aura = -1;

        public void OnGUI()
        {
            if (_ri != -1)
            {
                if (_quest.RequiredQuests.TrueForAll(x => x != _ri))
                    _quest.RequiredQuests.Add(_ri);
                _ri = -1;
            }

            if (_aura != -1)
            {
                if (_quest.Reward.Auras.TrueForAll(x=>x!=_aura))
                    _quest.Reward.Auras.Add(_aura);
                _aura = -1;
            }

            if (_markerDto.MapId != -1)
            {
                _quest.MapMarkers.Add(_markerDto);
                _markerDto = new QuestMarkerDto{MapId = -1};
            }

            if (_task.Type != QuestTaskTypes.None)
            {
                _quest.Tasks.Add(_task);
                _task = new QuestTaskDto{Type = QuestTaskTypes.None};
            }
            
            GUILayout.Label("Quest Data", EditorStyles.boldLabel);
            GUI.enabled = false;
            _quest.Id = EG.DelayedIntField("Id:", _nextId);
            GUI.enabled = true;
            
            for (var i = 0; i < _quest.RequiredQuests.Count; i++)
                _quest.RequiredQuests[i] = EG.DelayedIntField("Required Quest ID:", _quest.RequiredQuests[i]);
            _ri = EG.DelayedIntField("Add Required Quest ID:", _ri);

            _quest.Name = EG.DelayedTextField("Quest Name:", _quest.Name);

            GUILayout.Label("Quest Description");
            _quest.Description = EG.TextArea(_quest.Description);

            _quest.ZoneId = EG.DelayedIntField("Zone Id:", _quest.ZoneId);

            GUILayout.Label("Map markers:");
            for (var i = 0; i < _quest.MapMarkers.Count; i++)
            {
                GUILayout.Label("Map marker #"+(i+1));
                _quest.MapMarkers[i].MapId = EG.DelayedIntField("Map Id:", _quest.MapMarkers[i].MapId);
                _quest.MapMarkers[i].X = EG.DelayedFloatField("X: ", _quest.MapMarkers[i].X);
                _quest.MapMarkers[i].Y = EG.DelayedFloatField("Y: ", _quest.MapMarkers[i].Y);
            }

            _markerDto.MapId = EG.DelayedIntField("[Add Map Marker] Map Id:", _markerDto.MapId);
            
            GUILayout.Label("Tasks:");
            for (var i = 0; i < _quest.Tasks.Count; i++)
            {
                GUILayout.Label("Task #"+(i+1));
                _quest.Tasks[i].Type = (QuestTaskTypes) EG.EnumPopup("Type:", _quest.Tasks[i].Type);
                _quest.Tasks[i].TargetId = EG.DelayedIntField("Target Id:", _quest.Tasks[i].TargetId);
                _quest.Tasks[i].NeededAmount = EG.DelayedIntField("Needed amount:", _quest.Tasks[i].NeededAmount);
            }
            
            _task.Type = (QuestTaskTypes)EG.EnumPopup("[Add new task] TaskType:",_task.Type);
            
            GUILayout.Label("Reward");
            _quest.Reward.Xp = EG.DelayedIntField("XP reward:", _quest.Reward.Xp);
            _quest.Reward.Money = EG.DelayedIntField("Money:", _quest.Reward.Money);
            for (var i = 0; i < _quest.Reward.Auras.Count; i++)
            {
                _quest.Reward.Auras[i] = EG.DelayedIntField("Aura Id:", _quest.Reward.Auras[i]);
            }

            _aura = EG.DelayedIntField("Add aura:", _aura);
            
            if (GUILayout.Button("Save")) Save();

            if (GUILayout.Button("Reset")) Reset();
        }

        private void Save()
        {
            Saver.SaveQuest(_quest);
            Reset();
        }

        private void Reset()
        {
            _quest = new QuestDto();
            _aura = -1;
            _task = new QuestTaskDto{Type = QuestTaskTypes.None};
            _markerDto = new QuestMarkerDto{MapId = -1};
        }
    }
}