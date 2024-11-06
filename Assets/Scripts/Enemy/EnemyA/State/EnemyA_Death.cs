using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA_Death : EnemyState<EnemyA>
{
    public EnemyA_Death(EnemyA enemy, StateMachine<EnemyA> stateMachine, EnemyDATA enemyDATA, string name) : base(enemy, stateMachine, enemyDATA, name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.StartCoroutine(ResetState());
    }

    public override void Update()
    {
        
    }
    IEnumerator ResetState() 
    {
        yield return new WaitForSeconds(0.5f);
        stateMachine.ChangeState(enemy.EnemyA_Idle);
        enemy.DeadAnimation.SetActive(false);
        enemy.ResetPos();
        enemy.TurnOff();
    }
}
