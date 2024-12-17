using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f; // Movement speed
    public KeyCode forwardKey = KeyCode.W; // Key for moving forward
    public KeyCode backwardKey = KeyCode.S; // Key for moving backward
    public KeyCode leftKey = KeyCode.A; // Key for moving left
    public KeyCode rightKey = KeyCode.D; // Key for moving right

    private CharacterController characterController; // Reference to the CharacterController component

    private Vector3 moveDirection; // Stores the calculated movement direction

    [Header("Game Settings")]
    public int score = 0;
    public Fence fence;

    void Start(){
        characterController = GetComponent<CharacterController>();
    }

    void Update(){
        HandleMovement();

        if(score == 7){
            fence.DisableGate();
        }
    }

    private void HandleMovement()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // Check input keys and update movement direction
        if (Input.GetKey(forwardKey)){
            moveZ += 1f;
        }
        if (Input.GetKey(backwardKey)){
            moveZ -= 1f;
        }
        if (Input.GetKey(leftKey)) {
            moveX -= 1f;
        }
        if (Input.GetKey(rightKey)){
            moveX += 1f;
        }

        // Calculate movement direction and normalize
        Vector3 direction = transform.right * moveX + transform.forward * moveZ;
        moveDirection = direction.normalized * speed;

        // Apply movement to the CharacterController
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
