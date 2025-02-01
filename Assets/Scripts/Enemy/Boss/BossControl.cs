using BeehaviourTree;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class BossControl : BaseEnemy
{
    public Animator Animator{get; private set;}
    public Transform[] BossRoad;

    public GameObject BossBullet_1;
    public GameObject BossBullet_2;

    public int HP = 500;
    private SpriteRenderer sp;

    BehaviourTree tree;
    Selector sellector;

    public EnemyDATA enemyData;
    private void Awake()
    {
        //StateMachine = new StateMachine<BossControl>();
        Animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        tree = new BehaviourTree();

        sellector = new Selector();
    }

    private void Start()
    {
        Leaf ResetPosition = new Leaf(new ResetPosition(BossRoad, 1, 5f, gameObject),"Reset Position");

  
        Leaf attack1 = new Leaf(new Attack_1(5f, gameObject), "Attack 1");
        Leaf attack2 = new Leaf(new Attack_2(3 , BossBullet_1, 1f), "Attack 2");
        Leaf attack3 = new Leaf(new Attack_3(12, BossBullet_2, 5f), "Attack 3");


        sellector.AddChild(attack1);
        sellector.AddChild(attack3);
        sellector.AddChild(attack2);

        tree.AddChild(ResetPosition);
        tree.AddChild(sellector);
        
    }

    private void Update()
    {
        tree.Process();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GetHit();
            print("Va chạm");
        }
    }

    private void GetHit()
    {
        Animator.SetTrigger("Hit");
        HP--;

    }
}
