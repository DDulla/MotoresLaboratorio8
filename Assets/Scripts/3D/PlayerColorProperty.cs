using UnityEngine;

public class PlayerColorProperty : ColorProperty
{
    [SerializeField] private ColorPowerUpManager colorManager; 

    private void OnEnable()
    {
            colorManager.OnChangeColor += SetUpColor;
            Enemy.OnEnter += HandleEnemyCollision;
            Enemy.OnExit += HandleEnemyExit;
    }

    private void OnDisable()
    {
        if (colorManager != null)
        {
            colorManager.OnChangeColor -= SetUpColor;
            Enemy.OnEnter -= HandleEnemyCollision;
            Enemy.OnExit -= HandleEnemyExit;
        }
    }

    private void HandleEnemyCollision(ColorData enemyColor, int damage)
    {
        colorManager.ValidateCollision(enemyColor, damage);
        colorManager.BlockColorChange(true);
    }

    private void HandleEnemyExit()
    {
        colorManager.BlockColorChange(false);
    }
}