using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f; // Movement speed
    public KeyCode forwardKey = KeyCode.W; // Key for moving forward
    public KeyCode backwardKey = KeyCode.S; // Key for moving backward
    public KeyCode leftKey = KeyCode.A; // Key for moving left
    public KeyCode rightKey = KeyCode.D; // Key for moving right
    public KeyCode spaceKey = KeyCode.Space; // Key for jumping

    public bool jumped = false; // Used to check if the player has jumped
    [HideInInspector]
    public Rigidbody rb; // Reference to the Rigidbody component
    private Vector3 moveDirection; // Stores the calculated movement direction

    private Camera mainCam;
    private Camera winCam;

    [Header("Game Settings")]
    public int score = 0;
    public bool gameWon = false;
    public Fence fence;
    public Text scoreText;
    public GameObject winText;

    void Start(){
        rb = GetComponent<Rigidbody>();
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        winCam = GameObject.Find("WinCam").GetComponent<Camera>();

        mainCam.enabled = true;
        winCam.enabled = false;
    }

    void Update(){
        

        if(score >= 4 && fence != null){
            fence.DisableGate();
            fence = null;
        }

        if(gameWon){
            RotateCamera(0.25f);
        }else{
            HandleMovement();
        }


        // Debugging to check if grounded
        if(Input.GetKeyUp(KeyCode.G)){
            Debug.Log(isGrounded() + " - " + jumped);
        }

        // Reset the game
        if(Input.GetKeyUp(KeyCode.R)){
            ResetGame();
        }

        // cheat for winning
        if(Input.GetKey(KeyCode.Alpha0)){
            fence.DisableGate();
            fence = null;
            }

        
    }

    private void HandleMovement()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // Check input keys and update movement direction
        if(!jumped){
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
        }else if(isGrounded()){
            jumped = false;
        }

        if(Input.GetKeyDown(spaceKey) && GetComponent<Rigidbody>().velocity.y == 0){
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
            jumped = true;
        }

        // Calculate movement direction and normalize
        Vector3 direction = transform.right * moveX + transform.forward * moveZ;
        moveDirection = direction.normalized * speed;

        // Apply movement to the CharacterController
        //characterController.Move(moveDirection * Time.deltaTime);
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + moveDirection * Time.deltaTime);
    }

    public bool isGrounded(){
        float distToGround = GetComponent<CapsuleCollider>().bounds.extents.y;
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.05f);
    }

    public void UpdateScore(){
        scoreText.text = "x" + score;
    }

    public void WinGame(){
        gameWon = true;
        mainCam.enabled = false;
        winCam.enabled = true;
        winText.SetActive(true);
    }

    public void RotateCamera(float angle){
        transform.Rotate(Vector3.up * angle);
    }

    public void ResetGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
