using UnityEngine;
using System;

public class ShapeObject : MonoBehaviour
{
    private ColorShapeData shapeData;
    private SpriteRenderer spriteRenderer;
    public static Action<Sprite> OnChangeShape;

    private void Awake()
    {
        SetUp();
    }

    private void SetUp()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shapeData = ScriptableObject.CreateInstance<ColorShapeData>();
        shapeData.currentSprite = spriteRenderer.sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shapeData.currentSprite = spriteRenderer.sprite;
            OnChangeShape?.Invoke(shapeData.currentSprite);
        }
    }
}