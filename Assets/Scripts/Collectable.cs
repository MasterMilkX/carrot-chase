using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<PlayerMovement>().score++;
            Destroy(gameObject);
        }
    }
}
