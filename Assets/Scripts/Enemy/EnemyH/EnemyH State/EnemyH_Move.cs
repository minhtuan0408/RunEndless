using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyH_Move : EnemyState<EnemyH>
{
    int RandomRoad;
    int Target;
    float speed = 2.5f;
    
    public EnemyH_Move(EnemyH enemy, StateMachine<EnemyH> stateMachine, EnemyDATA enemyDATA, string name) : base(enemy, stateMachine, enemyDATA, name)
    {
    }
    public override void Enter()
    {
        base.Enter();
        RandomRoad = Random.Range(0, enemy.AnotherRoadPosition.Length);
        enemy.SpawnPos(RandomRoad);
        while (Target == RandomRoad || Target%2 == RandomRoad%2) 
        {
            Target = Random.Range(0, enemy.AnotherRoadPosition.Length);
        }
        Debug.Log(RandomRoad + "H" + Target);

        enemy.StartCoroutine(FireEnemyH());
    }
    public override void Update()
    {
        base.Update();
        enemy.MoveH(Target, speed);
    }
    IEnumerator FireEnemyH()
    {
        for (int i = 0; i < 3; i++) 
        {
            yield return new WaitForSeconds(1);
            enemy.InstantiateBullet();
        }
    }


}
