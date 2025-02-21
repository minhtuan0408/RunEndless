
using UnityEngine;


public class ChooseSkin : MonoBehaviour
{
    public RectTransform Choose;
    public int skinID;
    public void ChooseThis()
    {
        Choose.SetParent(transform, true);
        Choose.localPosition = new Vector2 (0, 0);
        AudioManager.Instance.PlaySFX("Choose");

        PlayerPrefs.SetInt("SelectedSkin", skinID);
        PlayerPrefs.Save();
    }
}
