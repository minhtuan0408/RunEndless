using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapDATA", menuName = "DATA/Map")]
public class MapDATA : ScriptableObject
{
    public float SpeedTime = 0.7f;

    [Header("TOP")]
    public float Speed_Top;
    

    
    [Header("MID")]
    public float Speed_Mid;
  


    [Header("Bot")]
    public float Speed_Bot;
    

}
