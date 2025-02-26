using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    public Text TextScore;
    public int Score;

    public GameObject PortUI;
    public Text PortText;
    public int PortCount;
    public GameObject Port;
    
    private void Awake()
    {
        Score = PlayerPrefs.GetInt("CurrentScore", 0);
        PortCount = 0;
    }

    private void Start()
    {
        TextScore.text = Score.ToString();
        PortText.text = PortCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            AudioManager.Instance.PlaySFX("Collect Gold");
            Score++;
            TextScore.text = Score.ToString();
        }
        if (collision.gameObject.CompareTag("Port Item"))
        {
            print("Ăn port");
            PortCount++;
            PortText.text = PortCount.ToString() + "/3";
            StartCoroutine(ShowPortItem());
            if (PortCount >= 3) Port.SetActive(true);
        }

        
    }

    IEnumerator ShowPortItem()
    {
        PortUI.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        PortUI.SetActive(false);
        
    }

}
