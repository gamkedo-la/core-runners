using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerMovement : MonoBehaviour
{
    
    public Rigidbody racer;
    public Transform racermodel;
  
    public float speed;
    public float dodge;
    public float lift;
    
    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
             racer.AddForce (transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.W))
        {
             racer.AddForce (transform.up * lift);
        }

          if (Input.GetKey(KeyCode.S))
        {
             racer.AddForce (-transform.up * lift);
        }

        if (Input.GetKey(KeyCode.A))
        {
            racermodel.Rotate (new Vector3(0, 0, 1) * Time.deltaTime * speed *0.5f, Space.World); 
            racer.AddForce (-transform.right * dodge);
        }

         if (Input.GetKey(KeyCode.D))
        {
            racermodel.Rotate (new Vector3(0, 0, -1) * Time.deltaTime * speed *0.5f, Space.World);
            racer.AddForce (transform.right * dodge);
        }

    }
}
