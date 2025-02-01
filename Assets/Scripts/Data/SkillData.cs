using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "DATA/Skill")]
public class SkillData : ScriptableObject
{
    [Header("Magnet")]
    public float TimeEffectMagnet = 8f;

    [Header("Shield")]
    public float TimeEffectShield = 8f;
}
