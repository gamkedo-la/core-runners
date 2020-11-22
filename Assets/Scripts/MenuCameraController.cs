using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController : MonoBehaviour
{
    public GameObject menuCamera;
    public Transform cameraTargetTransform;
    public float cameraSpeed;

    private void Update()
    {
        menuCamera.transform.position = Vector3.Slerp(menuCamera.transform.position, cameraTargetTransform.position, cameraSpeed);
        menuCamera.transform.rotation = Quaternion.Slerp(menuCamera.transform.rotation, cameraTargetTransform.rotation, cameraSpeed);
    }

    public void SetCameraTargetTransform(Transform targetTransform)
    {
        cameraTargetTransform = targetTransform;
    }
}
