using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Enemies;
    public GameObject Boss;

    private bool canSpawnEnemies;
    private bool canSpawnBoss;

    private void Start()
    {
        canSpawnBoss = true;
        canSpawnEnemies = true;
    }
    void Update()
    {
        if (Time.time > 10 && canSpawnEnemies == true)
        {
            canSpawnEnemies = false;
            Enemies.SetActive(true);
        }
        if (Time.time > 30 && canSpawnBoss == true)
        {
            canSpawnBoss = false;
            Boss.SetActive(true);
        }
        
        
    }
}
