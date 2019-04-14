using GBI.Scripts.Events;
using GBI.Scripts.Events.Args;
using UnityEngine;

namespace Geekbrains.TestScripts
{
    public class QuestZoneTest : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            EventManager.TriggerEvent(GameEventTypes.AreaEnter,
                new IdArgs {Id = 1, TriggeredUnitId = other.GetComponent<TestPlayer>().Id});
            Destroy(gameObject);
        }
    }
}