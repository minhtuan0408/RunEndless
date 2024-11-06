using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyA_Idle : EnemyState<EnemyA>
{
    private int RandomRoad;
    public EnemyA_Idle(EnemyA enemy, StateMachine<EnemyA> stateMachine, EnemyDATA enemyDATA, string name) : base(enemy, stateMachine, enemyDATA, name)  
    {
    }
    public override void Enter()
    {
        base.Enter();
        RandomRoad = Random.Range(0, enemy.RoadPosition.Length);
    }

    public override void Update()
    {
        base.Update();
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.RoadPosition[RandomRoad].transform.position, 5f * Time.deltaTime);
        if (enemy.transform.position.y == enemy.RoadPosition[RandomRoad].transform.position.y) 
        {
            
            stateMachine.ChangeState(enemy.EnemyA_Fire);
        }   
    }


}
