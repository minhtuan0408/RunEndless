using System.Collections;
using UnityEngine;


public class EnemyA : BaseEnemy
{
    #region StateMachine
    public EnemyDATA EnemyDATA;
    public StateMachine<EnemyA> StateMachine { get; private set; }

    public EnemyA_Idle EnemyA_Idle { get; private set; }
    public EnemyA_Fire EnemyA_Fire { get; private set; }
    public EnemyA_Death EnemyA_Death { get; private set; }
    #endregion

    public GameObject DeadAnimation;
    public Vector3 spawnEnemy;
    public Transform[] RoadPosition;
    public GameObject Bullet;
    public GameObject EnemyManager;

    #region Unity Function
    private void Awake()
    {
        StateMachine = new StateMachine<EnemyA>();
        EnemyA_Idle = new EnemyA_Idle(this, StateMachine, EnemyDATA,"Enemy_Idle");
        EnemyA_Fire = new EnemyA_Fire(this, StateMachine, EnemyDATA,"Enemy_Fire");
        EnemyA_Death = new EnemyA_Death(this, StateMachine, EnemyDATA, "Enemy_Death");
        spawnEnemy = new Vector3(1, 12, 2);

    }
    private void Start()
    {
        StateMachine.Initialize(EnemyA_Idle);
        
    }

    void Update()
    {
        StateMachine.currentEnemyState.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Shield")) 
        {
            
            
            DeadAnimation.SetActive(true);
            StateMachine.ChangeState(EnemyA_Death);
        }

    }

    #endregion

    public void ResetPos()
    {
        transform.position = spawnEnemy;
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }


    public void InstantiateBullet()
    {
        Instantiate(Bullet, transform.position, Quaternion.identity, EnemyManager.transform);
    }


}
