using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetLevelForNode : MonoBehaviour
{
    public RectTransform PlayerChosse;
    public int Index;
    private Coroutine moveCoroutine;
    private void Start()
    {
        PlayerChosse = MapLevelUIManager.instance.Choose;
    }
    public void ThisLevel()
    {
        MapLevelUIManager.instance.index = Index;
        print(MapLevelUIManager.instance.index);
        PlayerChosse.SetParent(transform, true);

        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(MoveThisNode());
    
    }

    IEnumerator MoveThisNode()
    {
        GameObject Player = PlayerChosse.GetChild(0).gameObject;
        Player.SetActive(false);
        Vector3 startPos = PlayerChosse.localPosition;
        Vector3 targetPos = Vector3.zero;
        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            PlayerChosse.localPosition = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        PlayerChosse.localPosition = targetPos;
        moveCoroutine = null;
        Player.SetActive(true);
    }

}
