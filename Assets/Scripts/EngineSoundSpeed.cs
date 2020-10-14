using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSoundSpeed : MonoBehaviour
{

    public AudioSource engine;

    public BoostButtonPress boostButton;

    float t = 0;

    public float p = 1;
    public float min = 1.0f;
    public float max = 1.2f;

    public bool reset;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (boostButton.boostbuttonPressed == true)
        {

            //if(p == min) { t = 0; }

            //p = Mathf.Lerp(min, max, t);
            //t += Time.deltaTime;

            p = max;

        }
        if (boostButton.boostbuttonPressed == false)
        {
            // if (p == max) { t = 0; }

            //engine.pitch = Mathf.Lerp(max, min, t);
            //t += Time.deltaTime;

            p = min;

        }

        engine.pitch = p;

    }
}
