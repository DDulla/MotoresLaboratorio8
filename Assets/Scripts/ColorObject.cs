using UnityEngine;
using System;

public class ColorObject : MonoBehaviour
{
    private ColorShapeData colorData;
    private SpriteRenderer spriteRenderer;
    public static Action<Color> OnChangeColor;

    private void Awake()
    {
        SetUp();
    }

    private void SetUp()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorData = ScriptableObject.CreateInstance<ColorShapeData>();
        colorData.currentColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            colorData.currentColor = spriteRenderer.color;
            OnChangeColor?.Invoke(colorData.currentColor);
        }
    }
}