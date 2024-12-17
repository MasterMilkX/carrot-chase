using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    [Header("Hover Settings")]
    public float hoverAmplitude = 0.5f; // Maximum height of the hover
    public float hoverFrequency = 1f;   // Speed of the hover

    private Vector3 startPosition; // Initial position of the object

    void Start(){
        // Store the initial position of the object
        startPosition = transform.position;
    }

    void Update(){
        // Calculate the new position based on a sine wave
        float hoverOffset = Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;

        // Apply the hover offset to the y-coordinate
        transform.position = new Vector3(
            startPosition.x, 
            startPosition.y + hoverOffset, 
            startPosition.z
        );
    }
}
