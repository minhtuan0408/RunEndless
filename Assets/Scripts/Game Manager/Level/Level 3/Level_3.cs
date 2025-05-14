using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_3 : GameManager
{
    public GameObject EnemiesManager;
    private bool canSpawnEnemies;

    public GameObject ItemManager;

    public GameObject CoinManager;

    private float TimeIN;
    private float currentTimeEnterGame;

    public Slider SliderTiming;
    private bool isTiming;
    public float TimeToEnd;




    public override void Awake()
    {

    }
    public override void Start()
    {
        base.Start();
        canSpawnEnemies = true;
        isTiming = true;

        TimeIN = Time.time;
    }
    public override void Update()
    {

        if (Time.time > TimeIN + 10 && canSpawnEnemies == true)
        {
            canSpawnEnemies = false;
            EnemiesManager.SetActive(true);
            ItemManager.SetActive(true);
        }
        if (isTiming)
        {
            SliderAction();
        }
        currentTimeEnterGame += Time.deltaTime;
    }

    private void SliderAction()
    {
        SliderTiming.value = currentTimeEnterGame * (1 / TimeToEnd);
        if (SliderTiming.value >= 1)
        {
            EnemiesManager.SetActive(false);
            ItemManager.SetActive(false);
            CoinManager.SetActive(false);
            isTiming = false;

            StartCoroutine(LoadNextLevel());
        }
    }

    // Time = Time cổng xuất hiện
    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(4f);
        Debug.Log("End game");
    }


}
