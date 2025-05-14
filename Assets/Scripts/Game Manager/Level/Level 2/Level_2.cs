using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Level_2 : GameManager
{
    public static Level_2 Instance;

    public GameObject Dialogue;

    public GameObject EnemiesManager;
    private bool canSpawnEnemies;

    private float TimeIN;
    private float currentTimeEnterGame;

    public GameObject[] ItemManager;


    public GameObject CoinManager;

    public override void Awake()
    {
        base.Awake();
        Instance = this;    
    }
    public override void Start()
    {
        base.Start();
        canSpawnEnemies = true;

        TimeIN = Time.time;
        StartCoroutine(TurnOn(Dialogue, 2f));
    }

    public override void Update()
    {

        if (Time.time > TimeIN + 10 && canSpawnEnemies == true)
        {
            canSpawnEnemies = false;
            EnemiesManager.SetActive(true);
            foreach ( GameObject a in ItemManager)
            {
                a.SetActive(true);
            }
            CoinManager.SetActive(true);
        }
        currentTimeEnterGame += Time.deltaTime;
    }
    IEnumerator TurnOn(GameObject game, float time)
    {
        yield return new WaitForSeconds(time);
        game.SetActive(true);
    }

    public void TurnOffSpawn()
    {
        EnemiesManager.SetActive(false);
    }
}
