using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopUILoadData : MonoBehaviour
{
    public ShopData ShopData;
    public List<GameObject> Skins;
    public List<GameObject> Skills;
    public int Coin;
    private void Start()
    {
        LoadAllUIShop();
        Coin = ShopData.Coin;
    }

    private void LoadAllUIShop()
    {
        int cnt = 0;
        foreach (GameObject go in Skins)
        {
            if (ShopData.shopItems.skinList[cnt].isUnlocked)
            {
                go.SetActive(false);
                cnt++;
                continue;
            }
            go.transform.Find ("Right Layout/Name").GetComponent<TextMeshProUGUI>().text = ShopData.shopItems.skinList[cnt].skinName;
            go.transform.Find ("Right Layout/Button Purchase/Text (TMP)").GetComponent<TextMeshProUGUI>().text = ShopData.shopItems.skinList[cnt].price.ToString();
            cnt++;
        }
        cnt = 0;
        foreach (GameObject go in Skills)
        {
            go.transform.Find("Right Layout/Name").GetComponent<TextMeshProUGUI>().text = ShopData.shopItems.skillList[cnt].name;
      
            go.transform.Find("Right Layout/Button Purchase/Text (TMP)").GetComponent<TextMeshProUGUI>().text = ShopData.shopItems.skillList[cnt].price.ToString();
            cnt++;
        }
    }
}
