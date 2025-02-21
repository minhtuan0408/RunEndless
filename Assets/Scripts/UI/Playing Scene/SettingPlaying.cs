using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPlaying : MonoBehaviour
{
    public GameObject SettingPanel;

    public void TurnOn()
    {
        SettingPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TurnOff()
    {
        SettingPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
