using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Magnet,
    Shield
}


public class TimeItem : MonoBehaviour, IObserverItem
{
    public ItemType Type;
    public PlayerData PlayerData;

    public float TimeLimit;
    public float CurrentTime;
    public Image timeFill;
    
    public Player player;

    private void OnDestroy()
    {
        if (player != null) 
        {
            player.RemoveObserver(this);
        }
    }

    private void Awake()
    {
        if (player != null)
        {
            player.AddObserver(this);
        }
    }
    private void Start()
    {
        switch (Type)
        {
            case ItemType.Magnet:
                TimeLimit = PlayerData.TimeMagnet;
                CurrentTime = PlayerData.TimeMagnet;
                break;
            case ItemType.Shield:
                TimeLimit = PlayerData.TimeShield;
                CurrentTime = PlayerData.TimeShield;
                break;
            default:
                TimeLimit = 500f;
                CurrentTime = 500f;
                break;
        }

        gameObject.SetActive(false);
    }


    private void Update()
    {
        CurrentTime -= Time.deltaTime;
        timeFill.fillAmount = CurrentTime/TimeLimit;

        if (CurrentTime <= 0)
        {
            CurrentTime = TimeLimit;
            gameObject.SetActive(false);
        }
    }

    public void OnNotify(ItemType type)
    {
       if (type == Type)
       {
            Debug.Log("Kich hoat" + type.ToString());
            CurrentTime = PlayerData.TimeMagnet;
            gameObject.SetActive(true);
       }
    }

    public void OffNotify(ItemType type)
    {
        if (type == Type)
        {
            gameObject.SetActive(false);
        }
    }

}
