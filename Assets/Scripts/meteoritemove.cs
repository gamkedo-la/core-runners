using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoritemove : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
         transform.Translate(-Time.deltaTime * 250f, -Time.deltaTime * 250f, 0);
    }
}
