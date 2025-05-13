using UnityEngine;

public class PlayerColorShapeController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private ColorShapeData playerData;

    private void Awake()
    {
        SetUp();
    }

    private void SetUp()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerData = ScriptableObject.CreateInstance<ColorShapeData>();
        playerData.currentColor = spriteRenderer.color;
        playerData.currentSprite = spriteRenderer.sprite;
    }

    private void OnEnable()
    {
        ColorObject.OnChangeColor += UpdateColor;
        ShapeObject.OnChangeShape += UpdateShape;
    }

    private void OnDisable()
    {
        ColorObject.OnChangeColor -= UpdateColor;
        ShapeObject.OnChangeShape -= UpdateShape;
    }

    private void UpdateColor(Color newColor)
    {
        spriteRenderer.color = newColor;
        playerData.currentColor = newColor;
    }

    private void UpdateShape(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
        playerData.currentSprite = newSprite;
    }
}