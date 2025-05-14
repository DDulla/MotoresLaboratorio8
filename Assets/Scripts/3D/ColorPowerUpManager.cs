using System;
using UnityEngine;

public class ColorPowerUpManager : MonoBehaviour
{
    [SerializeField] private ColorData[] colors;
    private ColorData currentColor;
    private int currentIndex = 0;
    private bool canChangeColor = true;

    public event Action<ColorData> OnChangeColor;

    private void Start()
    {
        if (colors.Length > 0)
        {
            currentColor = colors[currentIndex];
            OnChangeColor?.Invoke(currentColor);
        }
    }

    public void OnPreviousColor()
    {
        if (canChangeColor)
        {
            currentIndex = (currentIndex - 1 + colors.Length) % colors.Length;
            ChangeColorSelection();
        }
    }

    public void OnNextColor()
    {
        if (canChangeColor)
        {
            currentIndex = (currentIndex + 1) % colors.Length;
            ChangeColorSelection();
        }
    }

    private void ChangeColorSelection()
    {
        currentColor = colors[currentIndex]; 
        OnChangeColor?.Invoke(currentColor);
    }

    public void ValidateCollision(ColorData otherColor, int damage)
    {
        if (currentColor != otherColor)
        {
            GameManager.Instance.ModifyLife(-damage);
        }
    }

    public void BlockColorChange(bool state)
    {
        canChangeColor = !state;
    }
}