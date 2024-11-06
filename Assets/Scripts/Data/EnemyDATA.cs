using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Enemy DATA", menuName ="DATA/Enemy")]
public class EnemyDATA : ScriptableObject
{
    [Header("ENEMY A")]

    public float EASpeedAttack;
    public float EABulletSpeed;

    [Header("ENEMY B")]
    public float EBSpeedAttack;


    [Header("Boss")]
    public float BossSpeedAttack;
    public float BossBulletSpeed;
}
