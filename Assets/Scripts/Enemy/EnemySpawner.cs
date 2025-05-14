using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyPrefab;
    public GameObject[] Road;
    private float baseSpawnInterval = 5f;


    private float spawnTimer;
    private float currentSpawnInterval;

    private bool isSpawn;

    private Coroutine spawnEnemyACoroutine;
    private Coroutine spawnEnemyBCoroutine;
    private Coroutine spawnEnemyCCoroutine;
    void Start()
    {
        currentSpawnInterval = baseSpawnInterval;
        spawnTimer = currentSpawnInterval;
        isSpawn = false;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f && !isSpawn)
        {
            SpawnEnemy();
            spawnTimer = currentSpawnInterval;
        }
    }

    void SpawnEnemy()
    {
        print("Hello");
        int randomValue = Random.Range(0, 3);

        switch (randomValue)
        {
            case 0:
                StartSpawn(ref spawnEnemyACoroutine, SpawnEnemyA());
                break;
            case 1:
                StartSpawn(ref spawnEnemyBCoroutine, SpawnEnemyB());
                break;
            case 2:
                StartSpawn(ref spawnEnemyCCoroutine, SpawnEnemyC());
                break;
        }
    }
    /// Truyền biến coroutine theo tham chiếu, thay đổi giá trị của biến này từ bên trong hàm.
    void StartSpawn(ref Coroutine coroutine, IEnumerator SpawnMethod)
    {
        if (coroutine != null)
        {
            return;
        }

        coroutine = StartCoroutine(SpawnMethod);
    }


    private IEnumerator SpawnEnemyA()
    {
        isSpawn = true;
        int enemyCount = Random.value > 0.5f ? 4 : 6;
        GameObject chosenRoad = Road[Random.Range(0, Road.Length)];
        Vector3 basePosition = chosenRoad.transform.position;
        
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab[0], chosenRoad.transform.position, Quaternion.identity);
            enemy.SetActive(true);
            yield return new WaitForSeconds(0.2f);  
        }
        spawnEnemyACoroutine = null;
        isSpawn = false;
    }
    private IEnumerator SpawnEnemyB()
    {
        isSpawn = true;
        foreach (GameObject road in Road)
        {
            GameObject enemy = Instantiate(EnemyPrefab[1], road.transform.position, Quaternion.identity);
            enemy.SetActive(true);
            yield return new WaitForSeconds(1f);
        }
        spawnEnemyBCoroutine = null;
        isSpawn = false;
    }
    public IEnumerator SpawnEnemyC()
    {

        isSpawn = true;
        GameObject chosenRoad = Road[Random.Range(0, Road.Length)];
        Vector3 basePosition = chosenRoad.transform.position;

        for (int i = 0; i < 3; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-1f, 1f), 0, 0);
            Vector3 spawnPosition = basePosition + offset;

            GameObject enemy = Instantiate(EnemyPrefab[2], spawnPosition, Quaternion.identity);
            enemy.SetActive(true);
        }

        yield return null; 

        spawnEnemyCCoroutine = null;
        isSpawn = false;
    }

}