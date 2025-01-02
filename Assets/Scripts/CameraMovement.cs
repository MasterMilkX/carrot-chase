using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 400f; // Adjust sensitivity of the mouse
    private bool focused = true;        // Used to check if the game is focused and lock the camera
    private PlayerMovement playerMovement;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        focused = true;
        Cursor.visible = false;
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update(){
        // Get mouse input
        float rawMouseX = Input.GetAxis("Mouse X");
        if (Mathf.Abs(rawMouseX) < 0.2){
            rawMouseX = 0;
        }
        float mouseX = rawMouseX * mouseSensitivity * Time.deltaTime;

        // Apply rotation to the player body (attached to the camera)
        if(!playerMovement.gameWon){
            if(focused)
                transform.Rotate(Vector3.up * mouseX);                                // Horizontal rotation
            
            if(rawMouseX == 0){
                transform.Rotate(Vector3.zero);                                       // Stop rotation when the game is not focused
                playerMovement.rb.angularVelocity = Vector3.zero;                    // Stop the player from rotating when the game is not focused
            }
        }
            

        // Unlock the cursor when the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0)){
            focused = !focused;
        }

        // toggle the camera lock
        if(focused){
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        } else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
