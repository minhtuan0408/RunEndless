
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    public GameObject[] coinLine;
    public GameObject Coin;

    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    IEnumerator SpawnCoin()
    {
        int randomPosition = Random.Range(0, coinLine.Length);
        while (true) 
        {
            for (int i = 0; i < 6; i++)
            {
                yield return new WaitForSeconds(0.2f);
                Instantiate(Coin, coinLine[randomPosition].transform.position, Quaternion.identity);
            }
            int randomTime = Random.Range(2, 4);
            yield return new WaitForSeconds(randomTime);

            randomPosition = Random.Range(0, coinLine.Length);

        }
        
    }
}
