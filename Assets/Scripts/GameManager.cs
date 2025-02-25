using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Enemies;
    public GameObject Player;
    public GameObject LoadNextLevel;

    private PlayerCollect playerCollect;
    private Player player;

    private bool canSpawnEnemies;
    private bool canLoadNextLevel;

    private void Awake()
    {
        AudioManager.Instance.PlayMusic("Playing Theme");
    }
    private void Start()
    {
        playerCollect = Player.GetComponent<PlayerCollect>();
        player = Player.GetComponent<Player>();
        canSpawnEnemies = true;
        if (PlayerPrefs.GetInt("CurrentScore") < 50)
        {
            canLoadNextLevel = true;
        } 
        canLoadNextLevel = true;
    }
    void Update()
    {
        if (Time.time > 10 && canSpawnEnemies == true )
        {
            canSpawnEnemies = false;
            Enemies.SetActive(true);
        }

    }

}
