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

        public ResetPosition(Transform[] bossRoad, int index, float speed, GameObject boss)
        {
            this.bossRoad = bossRoad;
            this.index = index;
            this.speed = speed;
            this.boss = boss;
        }

        public Status Process() 
        {
            if (boss.transform.position == bossRoad[index].transform.position) return Status.Success;

            Vector2.MoveTowards(boss.transform.position, bossRoad[index].transform.position, speed);
            return Status.Running;
        }

        public void Reset() 
        {
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
        public Attack_2(int amountBullet, GameObject BulletPreb, float fireRate) 
        {
            this.amountBullet = amountBullet;
            this.Bullet = BulletPreb;
            this.fireRate = fireRate;
            currentTime = Time.time;
        }
        public Status Process()
        {
            if(cnt >= amountBullet)
            {
                return Status.Success;
            }
            if(Time.time > currentTime)
            {
                GameObject InsBullet = GameObject.Instantiate(Bullet);
                cnt++;
                currentTime = Time.time + fireRate;    
            }
            return Status.Running;
        }
        public void Reset() {
            UnityEngine.Debug.Log("het attack 2");
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
        public Attack_3(int amountBullet, GameObject BulletPreb, float speed)
        {
            this.speed = speed;
            this.amountBullet = amountBullet;
            this.Bullet = BulletPreb;
            angleStep = 360 / amountBullet;
        }
        public Status Process()
        {
            for (int i = 0; i < amountBullet; i++)
            {
                float radian = angle * Mathf.Deg2Rad;

                Vector2 bulletDirection = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));

                GameObject bulletInstance = GameObject.Instantiate(Bullet);

                Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();

                rb.velocity = bulletDirection * speed;
                angle += angleStep;

        
            }
            
            return Status.Success;
        }
        public void Reset() {
            UnityEngine.Debug.Log("het attack 3");
        }
    }
}
