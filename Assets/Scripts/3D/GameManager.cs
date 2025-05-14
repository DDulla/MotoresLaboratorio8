using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int playerLife = 10;
    private int playerCoins = 0;

    public event Action<int> OnLifeUpdate;
    public event Action<int> OnCoinUpdate;
    public event Action OnWin;
    public event Action OnLose;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GainCoin()
    {
        playerCoins++;
        OnCoinUpdate?.Invoke(playerCoins);
        CheckWin();
    }

    public void ModifyLife(int modify)
    {
        playerLife += modify;
        playerLife = Mathf.Clamp(playerLife, 0, 10);
        OnLifeUpdate?.Invoke(playerLife);
        ValidateLife();
    }

    public void CheckWin()
    {
        if (playerCoins >= 2) 
        {
            OnWin?.Invoke();
            SceneManager.LoadScene("Menu");
        }
    }

    public void ValidateLife()
    {
        if (playerLife <= 0)
        {
            OnLose?.Invoke();
            SceneManager.LoadScene("Menu");
        }
    }
}