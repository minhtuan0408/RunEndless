using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemy;
    
    
    private int amountSpawn;

    private bool canSpawn;



    private void Awake()
    {
        canSpawn = true;

    }

    private void Update()
    {
        if (canSpawn) 
        {
            StartCoroutine(SpawnEnemy());
        }
    }


    private IEnumerator SpawnEnemy()
    {
        canSpawn = false;
        amountSpawn = Random.Range(1, 3);
        int timeSpawn = Random.Range(1, 3);

        GameObject[] selectEnemy = GetRandomEnemies(Enemy, amountSpawn);
        
        foreach(GameObject enemy in selectEnemy) 
        {

            yield return new WaitForSeconds(timeSpawn);
            enemy.SetActive(true);
        }

        timeSpawn = Random.Range(3, 6);
        yield return new WaitForSeconds(timeSpawn);
        canSpawn = true;
    }

    private GameObject[] GetRandomEnemies(GameObject[] enemies, int numberToSelect)
    {
        List<GameObject> enemyList = enemies.ToList();
        enemyList = enemyList.OrderBy(a => Random.value).ToList();
        return enemyList.Take(numberToSelect).ToArray();
    }
}

