using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinReward : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
