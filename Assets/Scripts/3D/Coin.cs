using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Vector3 angleRotation = new Vector3(0, 100, 0);

    private void Update()
    {
        QuaternionRotation();
    }

    private void QuaternionRotation()
    {
        transform.Rotate(angleRotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GainCoin();
            Destroy(gameObject);
        }
    }
}