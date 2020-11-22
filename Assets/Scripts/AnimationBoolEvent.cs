using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationBoolEvent : MonoBehaviour
{
    public Animator animator;
    public string boolName = "myBool";

    public void SetBool(bool value)
    {
        animator.SetBool(boolName, value);
    }
}
