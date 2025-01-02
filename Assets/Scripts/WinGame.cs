using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision){
        if (collision.gameObject.tag == "Player"){
            Debug.Log("You win!");
            collision.gameObject.GetComponent<PlayerMovement>().WinGame();
        }
    }
}
