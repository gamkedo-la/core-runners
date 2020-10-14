using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSoundSpeed : MonoBehaviour
{

    public AudioSource engine;

    public BoostButtonPress boostButton;

    public float t = 1;

    public float p = 1;
    public float min;
    public float max;

    float temp = 0.0f;

    //public bool reset;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {

            Flip();

        }

        if (Input.GetButtonUp("Jump"))
        {

            Flip();

        }
        if (t < 1.0f)
        {
            t += Time.deltaTime;
        }
        p = Mathf.Lerp(max, min, t);

        

        engine.pitch = p;

    }


    public void Flip()
    {
        temp = max;
        max = min;
        min = temp;

        if (t > 1) { t = 1; }

        t = 1 - t;


    }


    
}
