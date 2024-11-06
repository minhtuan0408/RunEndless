using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : EnemyState<BossControl>
{
    public BossFire(BossControl enemy, StateMachine<BossControl> stateMachine, EnemyDATA enemyDATA, string name) : base(enemy, stateMachine, enemyDATA, name)
    {
    }
    private int randomAmountBullet;
    private int cnt;

    public override void Enter() 
    {
        cnt = 0;
        randomAmountBullet = 3;
        enemy.StartCoroutine(countFire());
    }

    IEnumerator countFire() 
    {
        while (cnt < randomAmountBullet) 
        {
            yield return new WaitForSeconds(0.5f);
            AudioManager.Instance.PlaySFX("Boss Fire");
            enemy.InsstantiateBullet();
            cnt++;
        }
        yield return new WaitForSeconds(3f);
        stateMachine.ChangeState(enemy.BossIdle);
    }
}
