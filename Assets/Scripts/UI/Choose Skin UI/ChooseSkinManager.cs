using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSkinManager : MonoBehaviour
{
    public static ChooseSkinManager Instance;

    public RectTransform Choose;

    public GameObject[] Skin;

    public GameObject Content;

    public ShopData Shop;
    private void Awake()
    {
        Instance = this;
        InitShop();
    }

    private void InitShop()
    {
        int index = 0;
        foreach (GameObject go in Skin) 
        {
            if (Shop.shopItems.skinList[index].isUnlocked == true)
            {
                Instantiate(Skin[index], Content.transform);
            }
            index++;
        }
    }
}
