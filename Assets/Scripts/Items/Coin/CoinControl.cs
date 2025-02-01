
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
                GameObject coin = CoinPooling.Instance.GetCoin();
                coin.SetActive(true);
                coin.transform.position = coinLine[randomPosition].transform.position;
                yield return new WaitForSeconds(0.2f);
                
            }
            int randomTime = Random.Range(2, 4);
            yield return new WaitForSeconds(randomTime);

            randomPosition = Random.Range(0, coinLine.Length);

        }
        
    }
}
