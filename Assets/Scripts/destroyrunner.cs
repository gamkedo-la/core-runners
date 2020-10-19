using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyrunner : MonoBehaviour
{
    
    public GameObject racerobject;
    public GameObject teleportexit;
     private void OnTriggerEnter(Collider other)
    {
    racerobject.transform.position = teleportexit.transform.position ;
    
    }

}
