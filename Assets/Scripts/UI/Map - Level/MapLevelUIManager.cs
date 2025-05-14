using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLevelUIManager : MonoBehaviour
{
    public static MapLevelUIManager instance;

    public int index;

    public GameObject[] Level;


    public RectTransform Choose;



    public LevelData levelData;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach (LevelUnlock level in levelData.levelUnlockList.levelUnlocks)
        {
            if (level.isUnlocked)
            {
                Level[level.level - 1].SetActive(true);
            }
        }

    }

    public void LoadThisLevel()
    {
        SceneManager.LoadScene($"Level {index}");

    }
}
