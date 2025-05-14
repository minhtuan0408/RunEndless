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

    #region Level Manager
    public LevelData LevelData;
    public string pathMapData;

    #endregion
    private void Awake()
    {
        Instance = this;
        path = Application.persistentDataPath + "/saveShopData.json";

        pathMapData = Application.persistentDataPath + "/saveMapLeveData.json";
    }
    void Start()
    {
        if (File.Exists(path))
        {
            LoadShopData();
        }
        else
        {
            InitializeShop();
            SaveShopData();
        }

        if (File.Exists(pathMapData))
        {
            LoadSaveMapLevel();
        }
        else
        {
            InitializeMapLevel();
            SaveMapLevel();
        }
    }

    public void InitializeShop()
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

    public void InitializeMapLevel()
    {
        LevelData.levelUnlockList = new LevelUnlockList
        {
            levelUnlocks = new List<LevelUnlock>
            {
                new LevelUnlock { level = 1 , isUnlocked = true},
                new LevelUnlock { level = 2, isUnlocked= false},
                new LevelUnlock { level = 3, isUnlocked= false}
            }
        };
        Debug.Log("Map Initialized!");
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

    public void SaveMapLevel()
    {
        string json = JsonUtility.ToJson(LevelData, true);
        File.WriteAllText(pathMapData, json);
        Debug.Log("Level Data Saved at: " + pathMapData);
    }
    public void LoadSaveMapLevel()
    {
        string json = File.ReadAllText(pathMapData);
        JsonUtility.FromJsonOverwrite(json, LevelData);
        Debug.Log("Level Data Loaded!");
    }
}
