using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyH : BaseEnemy
{
    
    public EnemyDATA EnemyHData;
    public StateMachine<EnemyH> StateMachine { get; private set; }
    public GameObject DeadAnimation;

    public Transform[] AnotherRoadPosition; /// another Road

    public EnemyH_Move EnemyH_Move { get; private set; }
    public GameObject Bullet;
    public GameObject EnemyManager;
    private void Awake()
    {
        StateMachine = new StateMachine<EnemyH>();
        EnemyH_Move = new EnemyH_Move(this, StateMachine, EnemyHData, "EnemyH_Move");
        StateMachine.Initialize(EnemyH_Move);

    }
    private void Start()
    {

    }

    private void Update()
    {
        StateMachine.currentEnemyState.Update();
    }

    public void MoveH(int target, float speed) 
    {
        transform.position = Vector3.MoveTowards(transform.position, AnotherRoadPosition[target].position, speed*Time.deltaTime);
        if (transform.position == AnotherRoadPosition[target].position)
        {
            TurnOff();
        }
    }

    public void InstantiateBullet()
    {
        Instantiate(Bullet, transform.position, Quaternion.identity, EnemyManager.transform);
    }

    public void SpawnPos(int i)
    {
        transform.position = AnotherRoadPosition[i].position;
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        StateMachine.ChangeState(EnemyH_Move);
    }
}
