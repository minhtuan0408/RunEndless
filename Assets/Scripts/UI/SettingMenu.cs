using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingMenu : MonoBehaviour
{

    public RectTransform imageRectTransform; // RectTransform của Image

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (IsPointerOverImage(touchPosition))
            {
                print("Đúng");
            }
           
        }
    }



    private bool IsPointerOverImage(Vector2 touchPos)
    {
        // Kiểm tra nếu vị trí chuột nằm trong RectTransform của Image
        return RectTransformUtility.RectangleContainsScreenPoint(imageRectTransform, touchPos);
    }
}
