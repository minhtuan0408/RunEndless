using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButon : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject SettingMenu;
    public void TurnOff()
    {
        foreach (GameObject go in gameObjects)
        {
            go.gameObject.SetActive(false);
        }
    }

    public void TurnOn()
    {
        SettingMenu.SetActive(true);
    }
}
