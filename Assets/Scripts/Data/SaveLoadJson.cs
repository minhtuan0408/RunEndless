using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SaveLoadJson : MonoBehaviour
{
    public static SaveLoadJson Instance;
    #region Shop
    public ShopData shopData;
    public string path;
    public TextMeshProUGUI TextNofication;
    #endregion

    #region Skin Select
    public GameObject[] Skin;
    #endregion
    private void Awake()
    {
        Instance = this;
        path = Application.persistentDataPath + "/saveShopData.json";
    }
    void Start()
    {
        

        
        if (File.Exists(path))
        {
            LoadShopData();
        }
        else
        {
            InitializeGame();
            SaveShopData();
        }
    }

    public void InitializeGame()
    {
        // Khởi tạo dữ liệu ban đầu
        shopData.shopItems = new ItemList
        {
            skinList = new List<Skin>
            {
                new Skin { skinName = "Skin 1", isUnlocked = true, price = 1 },
                new Skin { skinName = "Skin 2", isUnlocked = false, price = 100 },
                new Skin { skinName = "Skin 3", isUnlocked = false, price = 100 }
            },
            skillList = new List<Skill>
            {
                new Skill { name = "Magnet", price = 30, level = 1 },
                new Skill { name = "Shield", price = 30, level = 1 }
            }
        };

        shopData.Coin = 0;
        Debug.Log("Game Initialized!");
    }

    public void SaveShopData()
    {
        string json = JsonUtility.ToJson(shopData, true);
        File.WriteAllText(path, json);

        Debug.Log("Shop Data Saved at: " + path);
    }

    public void LoadShopData()
    {
        string json = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(json,shopData);
        TextNofication.text = shopData.Coin.ToString();
        Debug.Log("Shop Data Loaded!");
    }
}
