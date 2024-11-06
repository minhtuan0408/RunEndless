using UnityEngine;

public class EnemyB_Attack : EnemyState<EnemyB>
{
    public EnemyB_Attack(EnemyB enemy, StateMachine<EnemyB> stateMachine, EnemyDATA enemyDATA, string name) : base(enemy, stateMachine, enemyDATA, name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
    }
    public override void Update()
    {
        base.Update();
        MoveAttack(enemyDATA.EBSpeedAttack);
        if (enemy.transform.position.y < -6)
        {
            enemy.ResetPos();
            enemy.StateMachine.ChangeState(enemy.EnemyB_Idle);
            enemy.TurnOff();
        }
    }

    private void MoveAttack(float speed)
    {
        enemy.transform.Translate(Vector2.down * speed *Time.deltaTime);
        
    }
}
