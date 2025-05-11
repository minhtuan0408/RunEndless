using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] ItemSpawn;
    public GameObject[] Item;

    public int Min;
    public int Max;
    private void Start()
    {
        StartCoroutine(SpawnItem(Min, Max));
    }

    IEnumerator SpawnItem(int min, int max)
    {
        int randomPosition = Random.Range(0, ItemSpawn.Length);
        while (true)
        {

            int randomItem = Random.Range(0, Item.Length);
            Instantiate(Item[randomItem], ItemSpawn[randomPosition].transform.position, Quaternion.identity);
            int randomTime = Random.Range(min, max);

            yield return new WaitForSeconds(randomTime);
            randomPosition = Random.Range(0, ItemSpawn.Length);

        }

    }
}
