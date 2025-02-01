using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPooling : MonoBehaviour
{
    public static CoinPooling Instance { get; private set; }

    public int size = 30;
    public GameObject Coin;
    private Queue<GameObject> CoinPool = new Queue<GameObject>();

    private void Awake()
    {
        //CoinPooling pool = new CoinPooling();
        //Instance = pool;
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < size; i++) 
        {
            GameObject coin = Instantiate(Coin, transform);
            coin.SetActive(false);
            CoinPool.Enqueue(coin);
        }
    }

    public GameObject GetCoin()
    {
        if (CoinPool.Count > 0)
        {
            GameObject getCoin = CoinPool.Dequeue();
            return getCoin;
        }

        GameObject newCoin = Instantiate(this.Coin, transform);
        return newCoin;
    }

    public void ReturnPool(GameObject coin)
    {
        CoinPool.Enqueue(coin);
    }
}
