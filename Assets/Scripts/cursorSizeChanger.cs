using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cursorSizeChanger : MonoBehaviour
{
    // Variables are set for future use
    public float size { get; set; } = 1.25f;
    private RectTransform rectTransform;
    private GameObject test;

    void Start()
    {
        // Get the RectTransform component of the image
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Update the size of the image
        rectTransform.localScale = new Vector3(size, size, 1f);
    }
}