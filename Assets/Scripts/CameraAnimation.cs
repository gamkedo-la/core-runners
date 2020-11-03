using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public Animator camera;

    public void DefaultState()
    {
        camera.SetBool("isBoosting", false);
        camera.SetBool("outOfBoost", false);
    }
}
