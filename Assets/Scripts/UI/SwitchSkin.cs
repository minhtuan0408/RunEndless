using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class SwitchSkin : MonoBehaviour
{

    public GameObject[] SkinList;

    private int currentSkin;

    private void Awake()
    {
        currentSkin = 0;
    }

    private void Start()
    {
        SkinList[currentSkin].gameObject.SetActive(true);
    }

    public void SwitchLeft()
    {
        SkinList[currentSkin].SetActive(false);
        if (currentSkin == SkinList.Length - 1)
        {
            currentSkin = 0;
        }
        else
        {
            currentSkin++;
        }
        ChangeSkin(currentSkin);

    }

    public void SwitchRight()
    {
        SkinList[currentSkin].SetActive(false);
        if (currentSkin == 0)
        {
            currentSkin = SkinList.Length - 1;
        }
        else
        {
            currentSkin--;
        }

        ChangeSkin(currentSkin);

    }

    private void ChangeSkin(int index)
    {
        SkinList[index].gameObject.SetActive(true);
        SellectSkin(index);
    }

    private void SellectSkin(int index)
    {
        PlayerPrefs.SetInt("SelectedSkin", index);
        PlayerPrefs.Save();
    }
}
