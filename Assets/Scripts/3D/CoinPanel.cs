using UnityEngine;
using TMPro;

public class CoinPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;

    private void Start()
    {
        GameManager.Instance.OnCoinUpdate += UpdateCoins;
    }

    private void UpdateCoins(int coins)
    {
        coinsText.text = "Monedas: " + coins;
    }
}