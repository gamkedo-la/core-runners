using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeranimation : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Collider col1;
    public Collider col2;
    public Collider col3;
        private void OnTriggerEnter(Collider other)
    {
    //do this properly so can have 1 or 2 drop and think about resetting after crash
    // can change values to weight probability of different collapses
    var rand = Random.Range(0f,3f);
    if (rand <=1){
    anim1.SetTrigger("triggercollapse");
    col1.enabled = true;
    } else 
    if (rand <=2){
    anim2.SetTrigger("triggercollapse");
    col2.enabled = true;
    } else
    anim3.SetTrigger("triggercollapse");
    col3.enabled = true;
    }
}
