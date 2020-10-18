using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoritemove : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
         transform.Translate(0, -Time.deltaTime * 350f, 0);
    }
}
