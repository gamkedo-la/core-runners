using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteroriteclosingin : MonoBehaviour
{
    
    
    public float speed;

    void Update()
    {
        
       transform.localScale += Vector3.one * speed * Time.deltaTime;

    }
}
