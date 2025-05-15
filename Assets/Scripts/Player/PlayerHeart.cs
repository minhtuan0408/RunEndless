using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeart : MonoBehaviour
{
    public GameObject[] HeartImage;

    public int HeartCount;

    private void Awake()
    {
        HeartCount = PlayerPrefs.GetInt("CurrentHP", 0);
    }

    private void Start()
    {
        LoadHeartUI();
    }

    private void LoadHeartUI()
    {
        for (int i = 0; i < HeartImage.Length; i++)
        {
            HeartImage[i].SetActive(i < HeartCount);
        }
    }
}
