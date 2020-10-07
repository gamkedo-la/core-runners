using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RacerMovement : MonoBehaviour
{
    
    public Rigidbody racer;
    public Transform racermodel;

    public GameObject teleportexit;
    public GameObject racerobject;
      
    public float speed;
    public float boost;
    public float dodge;
    // public float lift;
    public float rotate;
   
    public LeftButtonPress leftbutton;
    public RightButtonPress rightbutton;
    public BoostButtonPress boostbutton;

    void FixedUpdate()
    {
       
           
       
         if (Input.GetKey(KeyCode.Space) || boostbutton.boostbuttonPressed == true)
        {
             racer.AddForce (transform.forward * boost * speed);
        } else {
             racer.AddForce (transform.forward * speed);
        }

          //Would this be better with rigidbody postion?
        if (Input.GetKeyDown(KeyCode.W))
        {
             racerobject.transform.position = teleportexit.transform.position ;
        }

      
        if (Input.GetKey(KeyCode.A) || leftbutton.leftbuttonPressed == true)
        {
             racer.AddForce (-transform.right * dodge);
             
            if(racermodel.localEulerAngles.z <=35f )
            {
              
               racermodel.Rotate (new Vector3(0, 0, 1) * Time.deltaTime * rotate , Space.World); 
            } 
        }
        
        if (Input.GetKey(KeyCode.A) == false && racermodel.rotation.z >0 && leftbutton.leftbuttonPressed == false && racermodel.rotation.z >0 )
        {
            racermodel.Rotate (new Vector3(0, 0, -1) * Time.deltaTime * rotate , Space.World); 
        }


         if (Input.GetKey(KeyCode.D) || rightbutton.rightbuttonPressed == true)
        {
               racer.AddForce (transform.right * dodge);
               // 325 due to way returns angle does not do as minus z as shown inspector
               if (racermodel.localEulerAngles.z >325f) 
               {
                  racermodel.Rotate (new Vector3(0, 0, -1) * Time.deltaTime * rotate, Space.World);
               }
        }

        if (Input.GetKey(KeyCode.D) == false && racermodel.rotation.z <0 && rightbutton.rightbuttonPressed == false && racermodel.rotation.z <0 )   
        {
            racermodel.Rotate (new Vector3(0, 0, 1) * Time.deltaTime * rotate , Space.World); 
        }

    }
}
