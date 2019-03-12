using System.Collections.Generic;
using Geekbrains.Skills.Auras;
using UnityEngine;

namespace Geekbrains.Unit
{
    public interface IDummyUnit
    {
        int Id { get; }
        
        string Name { get; }
        
        Vector3 Position { get; }

        Dictionary<ResourceTypes, int> CurrentResources { get; }

        /// <summary>
        /// If Unit suffers damage - call this
        /// </summary>
        /// <param name="value">damage w/o reduces from armor etc</param>
        /// <returns>how much damage was taken actually</returns>
        int TakeDamage(int value);

        void Heal(int value);

        void ApplyAura(int id, IDummyUnit caster);
        void ApplyAura(AuraBase aura);

        bool HasAura(int id);
        
        bool IsDead { get; }

        float DistanceTo(IDummyUnit target);
        float DistanceTo(Vector3 position);

        bool TryGetCharacteristic(CharacteristicTypes type, out int value);

        bool IsEnemyTo(IDummyUnit target);

        bool IsAllyTo(IDummyUnit target);

        void AddToCharacteristic(CharacteristicTypes type, int value);

        void AddCharacteristicPercent(CharacteristicTypes type, float value);
    }
}