using System.Linq;
using GBI.Scripts.Quests;
using GBI.Scripts.Storage;
using Geekbrains.Unit;
using UnityEngine;

namespace Geekbrains.TestScripts
{
    public class TestMain : MonoBehaviour
    {
        public QuestLogController QuestLogController { get; set; }
        public IDummyUnit Player { get; set; }
        
        private void Start()
        {
            Player = gameObject.GetComponent<TestPlayer>();
            QuestLogController = new QuestLogController(Player, new QuestLogModel());
            QuestLogController.Register(new XmlDevQuestStorage().GetQuest(1,Player.Id));
        }

        private void Update()
        {
            if (Time.frameCount%60!=0) return;
            Debug.Log("Frame Count"+Time.frameCount);
            Debug.Log("Quests active:"+QuestLogController.Quests.Count);
            Debug.Log("Tasks in 1st quest:"+QuestLogController.Quests[0].Tasks.Count);
            Debug.Log("Task 1:" + QuestLogController.Quests[0].Tasks[0].CurrentAmount +"/"+QuestLogController.Quests[0].Tasks[0].NeededAmount);
            Debug.Log("Quest status:"+QuestLogController.Quests[0].Tasks.All(x => x.IsCompleted));
        }
    }
}