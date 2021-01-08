using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboards : MonoBehaviour
{
    private Transform template;
    private Transform container;

    private void Awake()
    {
        container = transform.Find("Table");
        template = container.Find("Template");

        template.gameObject.SetActive(false);
        float templeHight = 40f;
        for (int i = 0; i < 7; i++)
        {
            Transform entryTransform = Instantiate(template, container);
            RectTransform rectTransform = entryTransform.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, -templeHight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }
}

