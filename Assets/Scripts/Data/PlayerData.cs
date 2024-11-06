using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData",menuName = "DATA/Player")]
public class PlayerData : ScriptableObject
{
    [Header("Skin")]

    public AnimatorOverrideController[] AnimatorOverride;
}
