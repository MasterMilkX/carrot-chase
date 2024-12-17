using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardView : MonoBehaviour
{
    public Transform faceTarget;

    void Start(){
        //find the player
        if(faceTarget == null)
            faceTarget = GameObject.Find("Player").transform;
    }

    void Update(){
        //rotate the object to face the player
        if (faceTarget != null)
       		transform.eulerAngles = faceTarget.eulerAngles;
    }
}
