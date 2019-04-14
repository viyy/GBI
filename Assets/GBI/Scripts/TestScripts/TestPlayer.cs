using System.Collections.Generic;
using Geekbrains.Skills.Auras;
using Geekbrains.Unit;
using UnityEngine;

namespace Geekbrains.TestScripts
{
    public class TestPlayer : MonoBehaviour, IDummyUnit
    {
        public int Id { get; } = 1;
        public string Name { get; } = "Test Player 1";
        public Vector3 Position { get; set; }
        public Dictionary<ResourceTypes, int> CurrentResources { get; }
        public int TakeDamage(int value, IDummyUnit source = null)
        {
            throw new System.NotImplementedException();
        }

        public void Heal(int value, IDummyUnit source = null)
        {
            throw new System.NotImplementedException();
        }

        public void ApplyAura(int id, IDummyUnit caster)
        {
            throw new System.NotImplementedException();
        }

        public void ApplyAura(AuraBase aura)
        {
            throw new System.NotImplementedException();
        }

        public bool HasAura(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool IsDead { get; }
        public bool IsAbleToUseSkills { get; }
        public float DistanceTo(IDummyUnit target)
        {
            throw new System.NotImplementedException();
        }

        public float DistanceTo(Vector3 position)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetCharacteristic(CharacteristicTypes type, out int value)
        {
            throw new System.NotImplementedException();
        }

        public bool IsEnemyTo(IDummyUnit target)
        {
            throw new System.NotImplementedException();
        }

        public bool IsAllyTo(IDummyUnit target)
        {
            throw new System.NotImplementedException();
        }

        public void AddToCharacteristic(CharacteristicTypes type, int value)
        {
            throw new System.NotImplementedException();
        }

        public void AddCharacteristicPercent(CharacteristicTypes type, float value)
        {
            throw new System.NotImplementedException();
        }

        public TargetModeTypes GetTargetModeTypesFor(IDummyUnit target)
        {
            throw new System.NotImplementedException();
        }

        public void KillUnit(IDummyUnit target)
        {
            throw new System.NotImplementedException();
        }
        
        private CharacterController ctrl;

        private void Start()
        {
            ctrl = gameObject.GetComponent<CharacterController>();
        }

        private void Update()
        {
            ctrl.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * 5 * Time.deltaTime);
        }
    }
}