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

    }

    IEnumerator ResetState()
    {
        yield return new WaitForSeconds(0.3f);
        stateMachine.ChangeState(enemy.EnemyB_Idle);
        AudioManager.Instance.PlaySFX("EnemyDie");
        enemy.DeadAnimation.SetActive(false);
        enemy.ResetPos();
        enemy.TurnOff();
    }

}
