using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] pivotPoints; 
    [SerializeField] private float speed = 3f; 
    private int currentPivotIndex = 0;
    [SerializeField] private Rigidbody rb;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (pivotPoints.Length == 0) return;

        Vector3 targetPosition = pivotPoints[currentPivotIndex].position;
        Vector3 direction = (targetPosition - transform.position).normalized;

        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            UpdatePivot();
        }
    }

    private void UpdatePivot()
    {
        currentPivotIndex = (currentPivotIndex + 1) % pivotPoints.Length;
    }
}