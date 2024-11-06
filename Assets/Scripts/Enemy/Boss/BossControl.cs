using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossControl : BaseEnemy
{
    #region StateManager
    public List<EnemyState<BossControl>> enemyStates { get; private set; }
    #endregion
    public Animator Animator{get; private set;}
    public Transform[] BossRoad;
    public GameObject BossBullet;
    public StateMachine<BossControl> StateMachine { get; private set; }
    
    public BossIdle BossIdle { get; private set; }
    public BossRandomAction BossRandomAttack { get; private set; }
    public BossAttack BossAttack { get; private set; }
    public BossHold BossHold { get; private set; }
    public BossFire BossFire { get; private set; }

    public EnemyDATA enemyData;
    private void Awake()
    {
        StateMachine = new StateMachine<BossControl>();
        Animator = GetComponent<Animator>();
        enemyStates = new List<EnemyState<BossControl>>();


        BossIdle = new BossIdle(this, StateMachine, enemyData, "Idle");
        BossHold = new BossHold(this, StateMachine, enemyData, "Hold");
        BossRandomAttack = new BossRandomAction(this, StateMachine, enemyData,"Random" );

        BossAttack = new BossAttack(this, StateMachine, enemyData, "Attack");
        BossFire = new BossFire(this, StateMachine, enemyData, "FIre");

        
    }

    private void Start()
    {
        enemyStates = new List<EnemyState<BossControl>>() {BossAttack, BossFire, BossFire };

        StateMachine.Initialize(BossIdle);
    }

    private void Update()
    {
        StateMachine.currentEnemyState.Update();
        
    }

    public void InsstantiateBullet()
    {
        Instantiate(BossBullet, transform.position, Quaternion.identity);
    }
}
