using System;
using System.Collections.Generic;
using GBI.Utility;
using Geekbrains;
using Geekbrains.Skills;
using Geekbrains.Storages;
using UnityEditor;
using UnityEngine;
using EG = UnityEditor.EditorGUILayout;

public class SkillEditor : EditorWindow
{
    private SkillDto _dto = new SkillDto
    {
        Cost = new SerializableDictionary<ResourceTypes, int>
        {
            {ResourceTypes.Mana, 0},
            {ResourceTypes.Energy, 0},
            {ResourceTypes.Rage, 0}
        }
    };

    private static bool _initFlag;
    private static int _newId = 1;
    private int _ri = -1;
    private static ISkillSaver _saver = new XmlSkillStorage();
    private SkillEffectDto _seDto = new SkillEffectDto {EffectType = SkillEffectTypes.None};

    [MenuItem("GBI/Skill Editor")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(SkillEditor));
        Debug.Log("Window Loaded.");
    }

    private void SaveSkill()
    {
        var toRemoveCost = new List<ResourceTypes>();
        foreach (var i in _dto.Cost)
            if (i.Value == 0)
                toRemoveCost.Add(i.Key);

        foreach (var type in toRemoveCost)
        {
            _dto.Cost.Remove(type);
        }

        foreach (var effect in _dto.Effects)
        {
            var toRemoveValues = new List<CharacteristicTypes>();
            foreach (var val in effect.Values)
                if (val.Value == 0)
                    toRemoveValues.Add(val.Key);
            foreach (var value in toRemoveValues)
            {
                effect.Values.Remove(value);
            }
        }

        _saver.SaveSkill(_dto);
        _dto = new SkillDto
        {
            Cost = new SerializableDictionary<ResourceTypes, int>
            {
                {ResourceTypes.Mana, 0},
                {ResourceTypes.Energy, 0},
                {ResourceTypes.Rage, 0}
            }
        };
        _seDto = new SkillEffectDto {EffectType = SkillEffectTypes.None};
        _newId = _saver.GetNewId();
    }

    private void ResetSkill()
    {
        _dto = new SkillDto
        {
            Cost = new SerializableDictionary<ResourceTypes, int>
            {
                {ResourceTypes.Mana, 0},
                {ResourceTypes.Energy, 0},
                {ResourceTypes.Rage, 0}
            }
        };
        _seDto = new SkillEffectDto {EffectType = SkillEffectTypes.None};
        _newId = _saver.GetNewId();
    }

    public void OnGUI()
    {
        if (!_initFlag)
        {
            _initFlag = true;
            _saver = new XmlSkillStorage();
            _newId = _saver.GetNewId();
        }

        if (_ri != -1)
        {
            if (_dto.RequiredSkills.TrueForAll(x => x != _ri))
                _dto.RequiredSkills.Add(_ri);
            _ri = -1;
        }

        if (_seDto.EffectType != SkillEffectTypes.None)
        {
            _dto.Effects.Add(_seDto);
            _seDto = new SkillEffectDto {EffectType = SkillEffectTypes.None};
        }


        GUILayout.Label("Skill Data", EditorStyles.boldLabel);
        _dto.Id = EG.DelayedIntField("Skill ID:", _newId);
        for (var i = 0; i < _dto.RequiredSkills.Count; i++)
            _dto.RequiredSkills[i] = EG.DelayedIntField("Required Skill ID:", _dto.RequiredSkills[i]);

        _ri = EG.DelayedIntField("Required Skill ID:", _ri);
        _dto.Name = EG.DelayedTextField("Skill Name:", _dto.Name);
        _dto.Range = EG.DelayedFloatField("Skill Range:", _dto.Range);
        _dto.Radius = EG.DelayedFloatField("Radius of AoE:", _dto.Radius);
        _dto.Cooldown = EG.DelayedFloatField("Cooldown:", _dto.Cooldown);
        //Magic time
        if (!_dto.Cost.ContainsKey(ResourceTypes.Mana))
            _dto.Cost.Add(ResourceTypes.Mana, 0);
        if (!_dto.Cost.ContainsKey(ResourceTypes.Energy))
            _dto.Cost.Add(ResourceTypes.Energy, 0);
        if (!_dto.Cost.ContainsKey(ResourceTypes.Rage))
            _dto.Cost.Add(ResourceTypes.Rage, 0);
        _dto.Cost[ResourceTypes.Mana] = EG.DelayedIntField("Mana cost:", _dto.Cost[ResourceTypes.Mana]);
        _dto.Cost[ResourceTypes.Energy] = EG.DelayedIntField("Energy Cost:", _dto.Cost[ResourceTypes.Energy]);
        _dto.Cost[ResourceTypes.Rage] = EG.DelayedIntField("Rage cost:", _dto.Cost[ResourceTypes.Rage]);
        _dto.Flags = (SkillFlags) EG.EnumFlagsField("Skill Flags", _dto.Flags);
        _dto.CastTime = EG.DelayedFloatField("Casting time:", _dto.CastTime);
        GUILayout.Label("Description:");
        _dto.Description = EG.TextArea(_dto.Description);
        GUILayout.Label("Effects:");
        foreach (var ef in _dto.Effects)
        {
            ef.EffectType = (SkillEffectTypes) EG.EnumPopup("Effect type:", ef.EffectType);
            ef.TargetType =
                (TargetModeTypes) EG.EnumFlagsField("Target types:", ef.TargetType);
            ef.BaseValue = EG.DelayedFloatField("Base Value of Effect:", ef.BaseValue);
            foreach (var t in (CharacteristicTypes[]) Enum.GetValues(typeof(CharacteristicTypes)))
            {
                if (!ef.Values.ContainsKey(t)) ef.Values.Add(t, 0);
                ef.Values[t] = EG.DelayedFloatField("Value for <StatName from LocaleManager>", ef.Values[t]);
            }

            GUILayout.Space(10);
        }

        _seDto.EffectType = (SkillEffectTypes) EG.EnumPopup("Effect type:", _seDto.EffectType);

        if (GUILayout.Button("Save")) SaveSkill();

        if (GUILayout.Button("Reset")) ResetSkill();
    }
}