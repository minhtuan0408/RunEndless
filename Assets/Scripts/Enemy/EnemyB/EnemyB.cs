using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : BaseEnemy
{
    #region StateMachine
    public EnemyDATA EnemyDATA;
    public StateMachine<EnemyB> StateMachine { get; private set; }

    public EnemyB_Idle EnemyB_Idle { get; private set; }
    public EnemyB_Attack EnemyB_Attack { get; private set; }
    public EnemyB_Death EnemyB_Death { get; private set; }

    #endregion
    public GameObject DeadAnimation;
    public Vector3 spawnEnemy;
    public Transform[] RoadPosition;



    private void Awake()
    {
        StateMachine = new StateMachine<EnemyB>();
        EnemyB_Idle = new EnemyB_Idle(this, StateMachine, EnemyDATA, "Enemy_Idle");
        EnemyB_Attack = new EnemyB_Attack(this, StateMachine, EnemyDATA, "Enemy_Attack");
        EnemyB_Death = new EnemyB_Death(this, StateMachine, EnemyDATA, "Enemy_Death");
        spawnEnemy = new Vector3(1, 12, 2);
        
    } 
    private void Start()
    {
        
        StateMachine.Initialize(EnemyB_Idle);
    }

    void Update()
    {
        StateMachine.currentEnemyState.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DeadAnimation.SetActive(true);
            StateMachine.ChangeState(EnemyB_Death);
        }
    }

    public void ResetPos()
    {
        transform.position = spawnEnemy;
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }


}
