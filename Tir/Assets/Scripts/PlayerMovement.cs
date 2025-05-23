using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [Header("Movement")]
   public float moveSpeed;

   public Transform orientation;

   float horizontalInput;
   float verticalInput;

   Vector3 moveDirection;

   Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void Update() {
        ProcessInput();
    }

    private void ProcessInput() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer() {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

}
