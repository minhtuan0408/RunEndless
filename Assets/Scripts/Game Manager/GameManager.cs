using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Needed
    public GameObject Player;
    public PlayerCollect playerCollect;
    public Player player;
    public PlayerHeart playerHeart;
    public Animator shake;

    public DataCollected DataCollected;
    #endregion

    public virtual void Awake()
    {

    }
    public virtual void Start()
    {
        AudioManager.Instance.PlayMusic("Playing Theme");
        playerCollect = Player.GetComponent<PlayerCollect>();
        playerHeart = Player.GetComponent<PlayerHeart>();
        player = Player.GetComponent<Player>();

    }
    public virtual void Update()
    {

    }

    public void SaveCurrentScore() => DataCollected.SavePrefData("CurrentScore", playerCollect.Score);
    public void SaveCurrentHP() => DataCollected.SavePrefData("CurrentHP", playerHeart.HeartCount);
}
