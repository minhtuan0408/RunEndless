using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

namespace BeehaviourTree
{
    public interface IStrategy
    {
        Status Process();

        void Reset()
        {

        }
    }

    public class ResetPosition : IStrategy
    {
        private Transform[] bossRoad;
        private int index;
        private float speed;
        private GameObject boss;
        private float Timing = 0;
        private float waitTime;

        public ResetPosition(Transform[] bossRoad, int index, float speed, GameObject boss, float waitTime)
        {
            this.bossRoad = bossRoad;
            this.index = index;
            this.speed = speed;
            this.boss = boss;
            this.waitTime = waitTime;
        }

        public Status Process() 
        {
            if (boss.transform.position == bossRoad[index].transform.position)
            {
                Timing += Time.deltaTime;
                if (Timing > waitTime) 
                {
                    return Status.Success;
                }
           
                return Status.Running;
            }

            boss.transform.position = Vector2.MoveTowards(boss.transform.position, bossRoad[index].transform.position, speed * Time.deltaTime);
            return Status.Running;
        }

        public void Reset() 
        {
           
            Timing = 0;
            index = Random.Range(0, bossRoad.Length);
        }
    }

    public class Attack_1 : IStrategy 
    {
        private GameObject boss;
        public float speed;
        public Attack_1(float speed, GameObject boss) 
        {
            this.boss = boss;
            this.speed = speed;
        }
        public Status Process()
        {
           
            if (boss.transform.position.y < -8)
            {
                return Status.Success;
            }
            boss.transform.Translate(Vector2.down * speed * Time.deltaTime );
            return Status.Running;
        }

        public void Reset()
        {
            
            boss.transform.position = new Vector3(0, 9, 0);
        }
    }

    public class Attack_2 : IStrategy
    {
        // ĐẠN LOẠI 1
        private GameObject Bullet;
        private int amountBullet;
        private int cnt = 0;
        private float fireRate;
        private float currentTime;

        private GameObject boss;
        public Attack_2(int amountBullet, GameObject BulletPreb, float fireRate, GameObject boss) 
        {
            this.amountBullet = amountBullet;
            this.Bullet = BulletPreb;
            this.fireRate = fireRate;
            this.boss = boss;
            currentTime = Time.time;
        }
        public Status Process()
        {
           
            if (cnt >= amountBullet)
            {
                return Status.Success;
            }
            if(Time.time > currentTime)
            {
                AudioManager.Instance.PlaySFX("BossFire2");
                GameObject InsBullet = GameObject.Instantiate(Bullet, boss.transform.position, Quaternion.identity);
                cnt++;
                currentTime = Time.time + fireRate;    
            }
            return Status.Running;
        }
        public void Reset() {
         
        }
    }

    public class Attack_3 : IStrategy
    {
        // ĐẠN LOẠI 2
        private GameObject Bullet;
        private int amountBullet;
        private float fireRate;
        private float speed;

        private float angleStep;
        private float angle = 0;

        private GameObject boss;
        public Attack_3(int amountBullet, GameObject BulletPreb, float speed, GameObject boss)
        {
            this.speed = speed;
            this.amountBullet = amountBullet;
            this.Bullet = BulletPreb;
            angleStep = 360 / amountBullet;
            this.boss = boss;
        }
        public Status Process()
        {
            AudioManager.Instance.PlaySFX("BossFire1");
            for (int i = 0; i < amountBullet; i++)
            {
                float radian = angle * Mathf.Deg2Rad;

                Vector2 bulletDirection = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));

                GameObject bulletInstance = GameObject.Instantiate(Bullet, boss.transform.position, Quaternion.identity);

                Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();

                rb.velocity = bulletDirection * speed;
                angle += angleStep;

        
            }
            
            return Status.Success;
        }
        public void Reset() {
          
        }
    }
}
