using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyState<BossControl> 
{
    public BossAttack(BossControl enemy, StateMachine<BossControl> stateMachine, EnemyDATA enemyDATA, string name) : base(enemy, stateMachine, enemyDATA, name)
    {
    }

    public override void Enter()
    {
        Debug.Log("Attack");
        base.Enter();   
    }

    public override void Update()
    {
        base.Update();
        enemy.transform.Translate(Vector2.down * 5f * Time.deltaTime);
        if (enemy.transform.position.y < -8)
        {
            enemy.transform.position = new Vector3(0, 9, 0);
            stateMachine.ChangeState(enemy.BossIdle);
        }
        
    }
}
