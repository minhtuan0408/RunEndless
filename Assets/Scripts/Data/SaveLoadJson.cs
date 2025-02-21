
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
public class Skin
{
    public string skinName;
    public int price;
    public bool isUnlocked;
}

public class Skill
{
    public string name;
    public int price;
    public int level;
}

[System.Serializable]
public class ShopData
{
    public List<Skin> skinList = new List<Skin>();
    public List<Skill> skillList = new List<Skill>();
}

public class SaveLoadJson : MonoBehaviour
{
    string path;
    private ShopData data;
    void Start()
    {
        path = Application.persistentDataPath + "/saveShopData.txt";
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

    public void InitializeGame() {
        ShopData data = new ShopData();
        data.skinList.Add(new Skin { skinName = "Skin 1", isUnlocked = true, price = 1  } );
        data.skinList.Add(new Skin { skinName = "Skin 2", isUnlocked = false, price = 100 });
        data.skinList.Add(new Skin { skinName = "Skin 3", isUnlocked = false, price = 100 });

        data.skillList.Add(new Skill { name = "Magnet", price = 30, level = 1 });
        data.skillList.Add(new Skill { name = "Shield", price = 30, level = 1 });

        Debug.Log("Game Initialized!");
    }

    void SaveShopData()
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);

        Debug.Log("Shop Data Saved!");
    }
    void LoadShopData()
    {
        string json = File.ReadAllText(path);
        data = JsonUtility.FromJson<ShopData>(json);

        Debug.Log("Shop Data Loaded!");
    }
}
