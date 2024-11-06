using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRandomAction : EnemyState<BossControl> 
{
    public BossRandomAction(BossControl enemy, StateMachine<BossControl> stateMachine, EnemyDATA enemyDATA, string name) : base(enemy, stateMachine, enemyDATA, name)
    {
    }

    public override void Enter()
    {
        Debug.Log("Random");
        base.Enter();
        enemy.Animator.SetBool("Idle", true);
    }
    public override void Exit()
    {
        base.Exit();
        enemy.Animator.SetBool("Idle", false);
    }
    public override void Update()
    {
        base.Update();
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.BossRoad[2].position, 2f * Time.deltaTime);
        if (enemy.transform.position.y == enemy.BossRoad[2].position.y)
        {
            stateMachine.ChangeState(enemy.BossFire);
        }
    }


}
