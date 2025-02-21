using BeehaviourTree;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class BossControl : BaseEnemy
{
    public Animator Animator{get; private set;}
    public Transform[] BossRoad;
    
    public GameObject BossBullet_1;
    public GameObject BossBullet_2;

    public int HP = 50;
    private bool stillAlive;
    public GameObject Explosion;
    public GameObject CoinReward;

    private SpriteRenderer sp;
    private BoxCollider2D boxCollider2D;
    BehaviourTree tree;
    Selector sellector;

    
    public EnemyDATA enemyData;
    private void Awake()
    {
        //StateMachine = new StateMachine<BossControl>();
        Animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        // Root
        tree = new BehaviourTree();

        stillAlive = true;
    }

    private void Start()
    {
        // Bậc 1
        Leaf ResetPosition = new Leaf(new ResetPosition(BossRoad, 1, 5f, gameObject, 3f),"Reset Position");
        sellector = new Selector();

        // Bậc 2
        Leaf attack1 = new Leaf(new Attack_1(5f, gameObject), "Attack 1");
        Leaf attack2 = new Leaf(new Attack_2(3 , BossBullet_1, 1f, gameObject), "Attack 2");
        Leaf attack3 = new Leaf(new Attack_3(24, BossBullet_2, 5f, gameObject), "Attack 3");

        // Bậc 3

        
        sellector.AddChild(attack1);
        sellector.AddChild(attack3);
        sellector.AddChild(attack2);

        tree.AddChild(ResetPosition);
        tree.AddChild(sellector);
        
    }

    private void Update()
    {
        if (stillAlive)
        {
           tree.Process(); 
        }
        
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
        if (HP <= 0)
        {
            Explosion.SetActive(true);
            stillAlive = false;
            boxCollider2D.enabled = false;
            StartCoroutine(CoinSpawn());


        }
    }

    IEnumerator CoinSpawn()
    {
        int cnt = 0;
        float angle = 0;
        float angleStep = 360 / 9;
        while (cnt < 3)
        {
            for (int i = 0; i < 9; i++)
            {
                float radian = angle * Mathf.Deg2Rad;

                Vector2 bulletDirection = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));

                Instantiate(CoinReward, transform.position, Quaternion.identity);




                angle += angleStep;


            }

            yield return new WaitForSeconds(1.8f);
            cnt++;
        }
        yield return new WaitForSeconds(3f);
        EndBoss();
    }

    void EndBoss()
    {
        SceneManager.LoadScene("EndGamePlay");
    }

 }
