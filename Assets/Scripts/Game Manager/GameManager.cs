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

    public Animator shake;
    #endregion

    public virtual void Awake()
    {

    }
    public virtual void Start()
    {
        AudioManager.Instance.PlayMusic("Playing Theme");
        playerCollect = Player.GetComponent<PlayerCollect>();
        player = Player.GetComponent<Player>();
    }
    public virtual void Update()
    {

    }
    
}
