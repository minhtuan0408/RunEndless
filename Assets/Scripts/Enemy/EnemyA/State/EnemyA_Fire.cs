using System.Collections;
using UnityEngine;
public class EnemyA_Fire : EnemyState<EnemyA>
{
    private bool endAction;
    public EnemyA_Fire(EnemyA enemy, StateMachine<EnemyA> stateMachine, EnemyDATA enemyDATA, string name) : base(enemy, stateMachine, enemyDATA, name)
    {
    }
    public override void Enter()
    {
        base.Enter();
        endAction = false;
        enemy.StartCoroutine(FireEnemyA());
    }

    public override void Update()
    {
        base.Update();
        if (endAction) 
        {
            MoveAttack(enemy.EnemyDATA.EASpeedAttack);
            if (enemy.transform.position.y < -8) 
            {
                enemy.StateMachine.ChangeState(enemy.EnemyA_Idle);
                enemy.ResetPos(); 
                enemy.TurnOff();
            }
        }

    }
    IEnumerator FireEnemyA()
    {
        int randomBullet = Random.Range(1, 4);
        int cnt = 0;
        while (cnt < randomBullet)
        {
            Debug.Log("Chuẩn bị bắn" + randomBullet);
            for (int i = 0; i < randomBullet; i++)
            {        
                cnt++;
                yield return new WaitForSeconds(2f);    
                enemy.InstantiateBullet();
            }
        }
        yield return new WaitForSeconds(2f);
        endAction = true;
        
    }

    private void MoveAttack(float speed)
    {
        enemy.transform.Translate(Vector2.down*speed  * Time.deltaTime);
    }
}
