using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.Unit
{
    public interface IUnit
    {
        int Id { get; }
        
        string Name { get; }
        
        Vector3 Position { get; }

        Dictionary<ResourceTypes, int> CurrentResources { get; }

        void TakeDamage(int value);

        void Heal(int value);

        void ApplyAura(int id);

        bool HasAura(int id);
        
        bool IsDead { get; }

        float DistanceTo(IUnit target);
        float DistanceTo(Vector3 position);
    }
}