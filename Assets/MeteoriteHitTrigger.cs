using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteHitTrigger : MonoBehaviour
{
    
    [SerializeField]
    private GameObject meterorite;
    private void OnTriggerEnter(Collider other){

        meterorite.SetActive(true);

    }
}
