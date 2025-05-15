using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollected : MonoBehaviour
{
    #region Prefs
    // currentHP, CurrentScore, SelectedSkin
    public object LoadPrefData(string name, object defaultValue)
    {
        if (defaultValue is int intValue)
        {
            return PlayerPrefs.GetInt(name, intValue);
        }
        else if (defaultValue is float floatValue)
        {
            return PlayerPrefs.GetFloat(name, floatValue);
        }
        else if (defaultValue is string stringValue)
        {
            return PlayerPrefs.GetString(name, stringValue);
        }
        else
        {
            Debug.LogWarning($"Chưa tồn tại hoặc sai dữ liệu: {defaultValue.GetType()}");
            return null;
        }
    }


    public void SavePrefData(string name, object value)
    {
        if (value is int intValue)
        {
            PlayerPrefs.SetInt(name, intValue);
        }
        else if (value is float floatValue)
        {
            PlayerPrefs.SetFloat(name, floatValue);
        }
        else if (value is string stringValue)
        {
            PlayerPrefs.SetString(name, stringValue);
        }
        else
        {
            Debug.LogWarning($"Không có định dạng này: {value.GetType()}");
            return;
        }
        PlayerPrefs.Save();
    }
    #endregion

    #region Scriptable Object
    #endregion

    #region Json save
    #endregion

}
