using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHomeScene : MonoBehaviour
{
    public Animator anim;
    public float TimeChangeScene;
    public string path;
    public ShopData ShopData;

    public void Start()
    {
        path = Application.persistentDataPath + "/saveShopData.json";
        UpdateDataToJson();
    }

    private void UpdateDataToJson()
    {
        ShopData.Coin += PlayerPrefs.GetInt("CurrentScore");
        SaveData();
    }

    private void SaveData()
    {
        string json = JsonUtility.ToJson(ShopData, true);
        File.WriteAllText(path, json);
    }
    public void NextLevel()
    {
        StartCoroutine(Play());
    }

    public IEnumerator Play()
    {
        anim.SetTrigger("Action");
        yield return new WaitForSeconds(TimeChangeScene);
        SceneManager.LoadScene("Start Menu");
    }
}
