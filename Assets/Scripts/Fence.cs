using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public void DisableGate(){
        //Debug.Log("BOOM!");
        Destroy(gameObject);
    }
}
