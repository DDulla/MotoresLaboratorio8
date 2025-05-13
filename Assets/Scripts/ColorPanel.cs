using UnityEngine;
using UnityEngine.UI;

public class ColorPanel : MonoBehaviour
{
    private Image colorImage;

    private void Awake()
    {
        colorImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        ColorObject.OnChangeColor += UpdateColor;
    }

    private void OnDisable()
    {
        ColorObject.OnChangeColor -= UpdateColor;
    }

    private void UpdateColor(Color newColor)
    {
        colorImage.color = newColor;
    }
}