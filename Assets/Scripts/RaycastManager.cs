using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float rayDistance;
    private Vector2 currentDirection;
    public CharacterController2D playerController;

    void FixedUpdate()
    {
        currentDirection = playerController.GetMovementInput();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, currentDirection, rayDistance, collisionLayer);
        Color rayColor = Color.white;

        if (hit.collider != null)
        {
            SpriteRenderer spriteRenderer = hit.collider.GetComponent<SpriteRenderer>();
            string objectName = hit.collider.gameObject.name;
            Vector3 objectPosition = hit.collider.transform.position;
            string objectTag = hit.collider.tag;

            if (hit.collider.CompareTag("Shape"))
            {
                Debug.Log("The App is " + objectName + " in the coordinates " + objectPosition + " and the tag is " + objectTag + " so, the shape is going to change to " + objectName + " icon!");
                rayColor = Color.green;
            }
            else if (hit.collider.CompareTag("Color"))
            {
                Debug.Log("The App is " + objectName + " in the coordinates " + objectPosition + " and the tag is " + objectTag + " so, the color is going to change to " + spriteRenderer.color);
                rayColor = Color.blue;
            }
        }
        Debug.DrawLine(transform.position, transform.position + (Vector3)currentDirection * rayDistance, rayColor);
    }
}