using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapDATA", menuName = "DATA/Map")]
public class MapDATA : ScriptableObject
{
    public float SpeedTime = 0.7f;

    public float Range;

    [Header("TOP")]
    public float Speed_Top = 5f;
    
    public Vector3 SpawnTranform_Top;
    
    [Header("MID")]
    public float Speed_Mid = 3f;
  
    public Vector3 SpawnTranform_Mid;

    [Header("Bot")]
    public float Speed_Bot = 1f;
    
    public Vector3 SpawnTranform_Bot;
}
