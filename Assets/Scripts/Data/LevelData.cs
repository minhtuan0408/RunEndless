using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelUnlock
{
    public int level;
    public bool isUnlocked;
}

[System.Serializable]
public class LevelUnlockList
{
    public List<LevelUnlock> levelUnlocks = new List<LevelUnlock>();
}

[CreateAssetMenu(fileName = "LevelData", menuName = "DATA/Level")]
public class LevelData : ScriptableObject
{
    public LevelUnlockList levelUnlockList = new LevelUnlockList();
}
