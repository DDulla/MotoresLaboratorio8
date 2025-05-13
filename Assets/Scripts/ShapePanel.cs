using UnityEngine;
using UnityEngine.UI;

public class ShapePanel : MonoBehaviour
{
    private Image shapeImage;

    private void Awake()
    {
        shapeImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        ShapeObject.OnChangeShape += UpdateShape;
    }

    private void OnDisable()
    {
        ShapeObject.OnChangeShape -= UpdateShape;
    }

    private void UpdateShape(Sprite newShape)
    {
        shapeImage.sprite = newShape;
    }
}