using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinReward1 : MonoBehaviour
{
    public RectTransform PositionMoveTo;

    public RectTransform CoinPool;

    public TextMeshProUGUI Text;


    private void Start()
    {
        StartCoroutine(TextCountChange());
        StartCoroutine(CoinActive());
    }


    IEnumerator TextCountChange()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Chạy Text");
        float timeSpawn = 2.5f / PlayerPrefs.GetInt("CurrentScore");
        print(PlayerPrefs.GetInt("CurrentScore"));
        for (int i = 0; i < PlayerPrefs.GetInt("CurrentScore"); i++)
        {
            Text.text = "TOTAL COIN : " + i;
            yield return new WaitForSeconds(timeSpawn);
            Debug.Log(i);
        }
    }



    IEnumerator CoinActive()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Chạy Coin");
        float timeSpawn = 2f/CoinPool.childCount;

        for (int i = 0; i < CoinPool.childCount; i++)
        {
            {
                RectTransform child = CoinPool.GetChild(i).GetComponent<RectTransform>();
                child.gameObject.SetActive(true);
                StartCoroutine(Move(child));
                yield return new WaitForSeconds(timeSpawn);
            }
        }

    }

    IEnumerator Move(RectTransform coin)
    {
        Vector2 startPos = coin.anchoredPosition;
        Vector2 target = new Vector2(0,0);
        float t = 0;

        while (t < 1f)
        {
            t += Time.deltaTime * 5f;
            coin.anchoredPosition = Vector2.Lerp(startPos, target, t);
            yield return null;
        }

        coin.gameObject.SetActive(false);
    }
}
