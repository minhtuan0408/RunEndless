﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    public Text TextScore;
    public int Score;
    
    private void Awake()
    {
        Score = PlayerPrefs.GetInt("CurrentScore", 0);

    }

    private void Start()
    {
        TextScore.text = Score.ToString();
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            AudioManager.Instance.PlaySFX("Collect Gold");
            Score++;
            TextScore.text = Score.ToString();
        }

        
    }


}
