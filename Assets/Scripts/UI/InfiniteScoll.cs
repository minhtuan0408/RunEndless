using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class InfiniteScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform viewPortTransform;
    public RectTransform contentPanelTransform; 
    public HorizontalLayoutGroup HLG; // layout khoảng cách các Skin

    public RectTransform[] ItemList; // Danh sách skin
    private List<RectTransform> spawnedItems = new List<RectTransform>();

    private float itemWidth;
    private int itemsToAdd;
    private bool isSnapping = false; // Tránh bị snap liên tục

    public RectTransform ChooseSkin;

    private void Start()
    {
        if (ItemList.Length == 0) return;

        itemWidth = ItemList[0].rect.width + HLG.spacing; // chiều rộng của 1 Item + HLG
        itemsToAdd = Mathf.CeilToInt(viewPortTransform.rect.width / itemWidth); // tổng Item hiển thị

        for (int i = 0; i < itemsToAdd; i++)
        {
            int num = (ItemList.Length - i - 1 + ItemList.Length) % ItemList.Length;
            RectTransform newItem = Instantiate(ItemList[num], contentPanelTransform);
            newItem.SetAsFirstSibling();
            spawnedItems.Add(newItem);
        }

        contentPanelTransform.localPosition = new Vector3(
            -itemWidth * itemsToAdd,
            contentPanelTransform.localPosition.y,
            0);
    }

    private void Update()
    {
        float leftBound = -itemWidth * itemsToAdd;
        float rightBound = 0;

        if (contentPanelTransform.localPosition.x > rightBound)
        {
            contentPanelTransform.localPosition -= new Vector3(ItemList.Length * itemWidth, 0, 0);
        }

        if (contentPanelTransform.localPosition.x < leftBound)
        {
            contentPanelTransform.localPosition += new Vector3(ItemList.Length * itemWidth, 0, 0);
        }
    }

    public void OnEndDrag()
    {
        if (!isSnapping)
        {
            StartCoroutine(SnapToClosestItem());
        }
    }

    private IEnumerator SnapToClosestItem()
    {
        float minDistance = Mathf.Infinity;
        RectTransform closestItem = null;

        foreach (RectTransform item in contentPanelTransform)
        {
            if (item == ChooseSkin) continue; 

            float distance = Mathf.Abs(item.localPosition.x - ChooseSkin.localPosition.x);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestItem = item;
            }
        }

        if (closestItem != null)
        {
            // Xác định khoảng cách cần dịch chuyển
            float offsetX = ChooseSkin.localPosition.x - closestItem.localPosition.x;
            Vector3 targetPosition = contentPanelTransform.localPosition + new Vector3(offsetX, 0, 0);

            // Dịch chuyển dần để tạo hiệu ứng mượt
            while (Mathf.Abs(contentPanelTransform.localPosition.x - targetPosition.x) > 0.1f)
            {
                contentPanelTransform.localPosition = Vector3.Lerp(
                    contentPanelTransform.localPosition,
                    targetPosition,
                    Time.deltaTime * 10f);
                yield return null;
            }

            // Đặt chính xác vị trí sau khi hoàn tất
            contentPanelTransform.localPosition = targetPosition;
        }

        isSnapping = false; // Cho phép cuộn lại
    }

}

