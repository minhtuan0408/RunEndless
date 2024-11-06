using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHold : EnemyState<BossControl>
{
    public BossHold(BossControl enemy, StateMachine<BossControl> stateMachine, EnemyDATA enemyDATA, string name) : base(enemy, stateMachine, enemyDATA, name)
    {
    }
    private int randomAttackLine;

    public override void Enter()
    {
        Debug.Log("Hold");
        base.Enter();
        enemy.Animator.SetBool("Hold", true);
        randomAttackLine = Random.Range(0, 3);
        enemy.StartCoroutine(Wait());
    }

    public override void Update()
    {
        base.Update();
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.BossRoad[randomAttackLine].transform.position, 5f*Time.deltaTime);

    }
    public override void Exit() 
    {
        base.Exit();
        enemy.Animator.SetBool("Hold", false);
    }

    IEnumerator Wait()
    {
        int randomIndexState = Random.Range(0, enemy.enemyStates.Count);
        yield return new WaitForSeconds(2 );
        Debug.Log(enemy.enemyStates[randomIndexState].ToString());
        stateMachine.ChangeState(enemy.enemyStates[randomIndexState]);
    }
}



