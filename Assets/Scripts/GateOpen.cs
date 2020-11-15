using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other){
        Debug.Log ("Gate trigger");
        anim.enabled = true;

    }




}
