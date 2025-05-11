using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_1 : GameManager
{
    public GameObject EnemiesManager;
    private bool canSpawnEnemies;

    public GameObject ItemManager;

    private float TimeIN;
    private float currentTimeEnterGame;

    public Slider SliderTiming;
    private bool isTiming;
    public float TimeToEnd;

    public GameObject NextLevel;

    public PlayerLevel1ActionPlus PlayerLevel1ActionPlus;


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
            isTiming = false;

            StartCoroutine(LoadNextLevel(3,3));
            PlayerLevel1ActionPlus.PlayerOff();
        }
    }

    // Time = Time cổng xuất hiện
    private IEnumerator LoadNextLevel(float totalTime, int shakeTime)
    {
        float interval = totalTime / shakeTime;

        StartCoroutine(PlayerLevel1ActionPlus.ResetPos());

        for (int i = 0; i < shakeTime; i++)
        {
            shake.SetTrigger("Shake");
            yield return new WaitForSeconds(interval);
        }

        yield return new WaitForSeconds(interval);

        NextLevel.SetActive(true);

        yield return new WaitForSeconds(4f);

        StartCoroutine(PlayerLevel1ActionPlus.MoveUp());
    }


}
