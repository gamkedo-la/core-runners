using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerMovement : MonoBehaviour
{
    
    public Rigidbody racer;
    public Transform racermodel;
  
    public float speed;
    public float boost;
    public float dodge;
    // public float lift;
    public float rotate;
  

    
    
    
    void FixedUpdate()
    {
       
           
       
         if (Input.GetKey(KeyCode.Space))
        {
             racer.AddForce (transform.forward * boost * speed);
        } else {
             racer.AddForce (transform.forward * speed);
        }

       /*  if (Input.GetKey(KeyCode.W))
        {
             racer.AddForce (transform.up * lift);
        }

          if (Input.GetKey(KeyCode.S))
        {
             racer.AddForce (-transform.up * lift);
        }  */

        if (Input.GetKey(KeyCode.A))
        {
             racer.AddForce (-transform.right * dodge);
            if(racermodel.rotation.z <=35 )
            {
              Debug.Log ("I can turn");
               racermodel.Rotate (new Vector3(0, 0, 1) * Time.deltaTime * rotate , Space.World); 
            } else
             {
                     Debug.Log ("no more turn for me");
            }
        }
        
        if (Input.GetKey(KeyCode.A) == false && racermodel.rotation.z >0)
        {
            racermodel.Rotate (new Vector3(0, 0, -1) * Time.deltaTime * rotate , Space.World); 
        }


         if (Input.GetKey(KeyCode.D))
        {
               racer.AddForce (transform.right * dodge);
               if (racermodel.rotation.z >=-35)
               {
               racermodel.Rotate (new Vector3(0, 0, -1) * Time.deltaTime * rotate, Space.World);
               }
        }

        if (Input.GetKey(KeyCode.D) == false && racermodel.rotation.z <0)   
        {
            racermodel.Rotate (new Vector3(0, 0, 1) * Time.deltaTime * rotate , Space.World); 
        }

    }
}
