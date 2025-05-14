using UnityEngine;
using TMPro;

public class LifePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text lifeText;

    private void Start()
    {
        GameManager.Instance.OnLifeUpdate += UpdateLife;
    }

    private void UpdateLife(int life)
    {
        lifeText.text = "Lives: " + life;
    }
}