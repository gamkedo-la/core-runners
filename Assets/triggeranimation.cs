using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeranimation : MonoBehaviour
{
    public Animator anim;
    
    
        private void OnTriggerEnter(Collider other)
    {
    anim.SetTrigger("triggercollapse");
    }
}
