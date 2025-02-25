using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SkinButton : MonoBehaviour
{
    public int Index;

    public ShopData ShopData;


    int cost;

    bool isUnlock;

    string pathData;

    private void Start()
    {
        cost = ShopData.shopItems.skinList[Index].price;
        isUnlock = ShopData.shopItems.skinList[Index].isUnlocked;
        pathData = SaveLoadJson.Instance.path;

    }

    public void BuyButton()
    {
        if (isUnlock)
        {
            gameObject.SetActive(false);
        }
        else if (isUnlock == false && ShopData.Coin >= cost) 
        {
            ShopData.Coin -= cost;
            ShopData.shopItems.skinList[Index].isUnlocked = true;
            gameObject.SetActive(false);
            AddSkinToChoose();
            SaveData();
        }


    }

    private void AddSkinToChoose()
    {
        Instantiate(ChooseSkinManager.Instance.Skin[Index], ChooseSkinManager.Instance.Content.transform);
    }
    private void SaveData()
    {
        SaveLoadJson.Instance.TextNofication.text = ShopData.Coin.ToString();   
        string json = JsonUtility.ToJson(ShopData, true);
        File.WriteAllText(pathData, json);
    }
}
