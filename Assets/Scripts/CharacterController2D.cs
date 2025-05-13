using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D myRBD2;
    private float velocity = 5f;
    private Vector2 movementInput;

    private void Awake()
    {
        myRBD2 = GetComponent<Rigidbody2D>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        myRBD2.velocity = movementInput * velocity;
    }

    public Vector2 GetMovementInput()
    {
        return movementInput;
    }
}