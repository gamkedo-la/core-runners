using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSoundSpeed : MonoBehaviour
{

    public AudioSource engine;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        engine.pitch = GetComponent<RacerMovement>().speed / 200;

    }
}
