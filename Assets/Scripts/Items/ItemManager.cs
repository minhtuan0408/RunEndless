using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] ItemSpawn;
    public GameObject[] Item;

    private void Start()
    {
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem()
    {
        int randomPosition = Random.Range(0, ItemSpawn.Length);
        while (true)
        {
            int randomItem = Random.Range(0, Item.Length);
            Instantiate(Item[randomItem], ItemSpawn[randomPosition].transform.position, Quaternion.identity);
            int randomTime = Random.Range(3,5);
            yield return new WaitForSeconds(randomTime);

            randomPosition = Random.Range(0, ItemSpawn.Length);

        }

    }
}
