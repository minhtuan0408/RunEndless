using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : EnemyState<BossControl>
{
    public BossIdle(BossControl enemy, StateMachine<BossControl> stateMachine, EnemyDATA enemyDATA, string name) : base(enemy, stateMachine, enemyDATA, name)
    {
    }

    public override void Enter()
    {
        Debug.Log("Idle");
        base.Enter();
        enemy.StartCoroutine(WaitTime());
    }
    public override void Update() 
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.BossRoad[1].position, 5f * Time.deltaTime);
    }
    IEnumerator WaitTime() 
    {
        yield return new WaitForSeconds(3f);
        stateMachine.ChangeState(enemy.BossHold);
    }
}
