using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController3D : MonoBehaviour
{
    private Rigidbody myRB;
    private float speed = 5f;
    private float jumpForce = 12f;
    private Vector2 moveInput;
    private bool isGrounded;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ApplyPhysics();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        myRB.velocity = new Vector3(moveInput.x * speed, myRB.velocity.y, moveInput.y * speed);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            myRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

   private void ApplyPhysics()
   {

   }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}