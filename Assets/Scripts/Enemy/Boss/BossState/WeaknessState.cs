using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class WeaknessState : EnemyState<BossControl>
{
    public WeaknessState(BossControl enemy, StateMachine<BossControl> stateMachine, EnemyDATA enemyDATA, string name) : base(enemy, stateMachine, enemyDATA, name)
    {


    }
    private int pos;
    public override void Enter()
    {
        base.Enter();
        pos = Random.Range(0, enemy.BossRoad.Length);
    }

    public override void Update()
    {
        base.Update();
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.BossRoad[pos].transform.position, 5f * Time.deltaTime);
    }


}
