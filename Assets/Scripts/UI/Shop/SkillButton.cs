using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum SkillShop
{
    Magnet = 0, Shield = 1
}
public class SkillButton : MonoBehaviour
{
    public SkillShop SkillType;

    public ShopData ShopData;

    public GameObject SkillPower;
    public GameObject Button;
    private int levelPower;

    int cost;

    string pathData;
    private void Start()
    {
        cost = ShopData.shopItems.skillList[(int)SkillType].price;
        pathData = SaveLoadJson.Instance.path;

        levelPower = ShopData.shopItems.skillList[(int)SkillType].level;

        UpdateSkillLevel();
    }

    private void UpdateSkillLevel()
    {
        if (levelPower >= 8)
        {
            Button.SetActive(false);
        }

        for (int i = 0; i < levelPower; i++)
        {
            SkillPower.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void BuyThisSkill()
    {
        if (levelPower >= 8)
        {
            Button.SetActive(false);
        }
        if (ShopData.Coin >= cost)
        {
            levelPower++;
            ShopData.Coin -= cost;
            UpdateSkillLevel() ;
            SaveData();
        }

    }
    private void SaveData()
    {
        ShopData.shopItems.skillList[(int)SkillType].level = levelPower;
        SaveLoadJson.Instance.TextNofication.text = ShopData.Coin.ToString();
        print(SaveLoadJson.Instance.TextNofication.text);

        string json = JsonUtility.ToJson(ShopData, true);
        File.WriteAllText(pathData, json);
    }
}
