using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchWidth : MonoBehaviour
{
    public Transform inputArea;

    RectTransform myRect;

    public GridLayoutGroup layout;

    private void Start()
    {
        myRect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 size = myRect.sizeDelta;

        size.x = inputArea.childCount * layout.cellSize.x + ((inputArea.childCount - 1) * (layout.spacing.x));

        myRect.sizeDelta = size;
    }
}
