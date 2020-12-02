using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destroyrunner : MonoBehaviour
{
    
    //public GameObject racerobject;
    //public GameObject teleportexit;
     private void OnTriggerEnter(Collider other)
    {
    //racerobject.transform.position = teleportexit.transform.position ;
    RacerMovement.currentBoostValue = 5.0f;
    SceneManager.LoadScene(1);
    }

}
