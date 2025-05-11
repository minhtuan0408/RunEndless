using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class BulletPooling : MonoBehaviour
{
    public static BulletPooling Instance { get; private set;}
    public int size = 3;

    [System.Serializable]
    public struct BulletType
    {
       public string name;
       public GameObject prefab;
    }


    public List<BulletType> bulletList;

    private Dictionary<string, Queue<GameObject>> bulletPool;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }



        bulletPool = new Dictionary<string, Queue<GameObject>>();
    }

    public void Start()
    {
        foreach (BulletType type in bulletList) 
        {
            Queue<GameObject> newPool = new Queue<GameObject>();
            for (int i = 0; i < size; i++)
            {
                GameObject bullet = Instantiate(type.prefab, transform);
                bullet.SetActive(false);
                newPool.Enqueue(bullet);
            }
            bulletPool.Add(type.name, newPool);
        }
    }

    public GameObject GetBullet(string name, BulletType type)
    {
        if (bulletPool.ContainsKey(name))
        {
            Queue<GameObject> bullet = bulletPool[name];
            if ( bullet.Count > 0) 
            {
                GameObject Bullet = bullet.Dequeue();
                Debug.Log(bullet.Count);
                Bullet.SetActive(true);
                return Bullet;
            }
            Debug.Log(bullet.Count);
            GameObject newBullet = Instantiate(bulletList[1].prefab, transform);
            return newBullet;
        }
        return null;
    }

    public void ReturnPool(GameObject bullet, string name) 
    {
        Queue<GameObject> listBullet = bulletPool[name];
        listBullet.Enqueue(bullet);
    }
}
