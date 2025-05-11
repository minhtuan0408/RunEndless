using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB_Idle : EnemyState<EnemyB>
{
    private int RandomRoad;
    private int count = 1;
    public EnemyB_Idle(EnemyB enemy, StateMachine<EnemyB> stateMachine, EnemyDATA enemyDATA, string name) : base(enemy, stateMachine, enemyDATA, name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        RandomRoad = Random.Range(0, enemy.RoadPosition.Length);
        count = 1;
        Debug.Log("EnemyB Idle");
    }

    public override void Update()
    {
        base.Update();
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.RoadPosition[RandomRoad].transform.position, 10f * Time.deltaTime);
        if (count >=1 && enemy.transform.position.y - enemy.RoadPosition[RandomRoad].transform.position.y < .2) 
        {
            count--;
            enemy.StartCoroutine(WarningToAttack());
            Debug.Log("Chạy");
        }

    }
    IEnumerator WarningToAttack()
    {
        Debug.Log("Cảnh báo tấn công");
        yield return new WaitForSeconds(2f);
        stateMachine.ChangeState(enemy.EnemyB_Attack);
      
    }
}
