using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// JsonUtility nó thành JSON.
[System.Serializable]
public class Skin
{
    public string skinName;
    public int price;
    public bool isUnlocked;
}
[System.Serializable]
public class Skill
{
    public string name;
    public int price;
    public int level;
}

[System.Serializable]
public class ItemList
{
    public List<Skin> skinList = new List<Skin>();
    public List<Skill> skillList = new List<Skill>();
}
[CreateAssetMenu(fileName = "ShopData", menuName = "DATA/Shop")]
public class ShopData : ScriptableObject
{
    public ItemList shopItems = new ItemList();

    public int Coin;
}
