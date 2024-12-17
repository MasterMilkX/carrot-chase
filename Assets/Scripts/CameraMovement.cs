using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 400f; // Adjust sensitivity of the mouse
    private bool focused = true;        // Used to check if the game is focused and lock the camera

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        focused = true;
        Cursor.visible = false;
    }

    void Update(){
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // Apply rotation to the player body (attached to the camera)
        if(focused)
            transform.Rotate(Vector3.up * mouseX);                                // Horizontal rotation

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
