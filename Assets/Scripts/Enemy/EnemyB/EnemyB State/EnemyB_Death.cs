using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB_Death : EnemyState<EnemyB>
{
    public EnemyB_Death(EnemyB enemy, StateMachine<EnemyB> stateMachine, EnemyDATA enemyDATA, string name) : base(enemy, stateMachine, enemyDATA, name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.StartCoroutine(ResetState());
        Debug.Log("Death");
    }

    IEnumerator ResetState()
    {
        yield return new WaitForSeconds(0.5f);
        stateMachine.ChangeState(enemy.EnemyB_Idle);
        enemy.DeadAnimation.SetActive(false);
        enemy.ResetPos();
        enemy.TurnOff();
    }

}
