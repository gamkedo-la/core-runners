using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class fps : MonoBehaviour
{
 
    public float timer, refresh, avgFramerate;
    string display = "{0} FPS";
    [SerializeField] private TextMeshProUGUI fpscounter;
 
    
 
 
    private void Update()
    {
        // smoothDeltaTime is a smoothed version of fixedDeltaTime 
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;
 
        if(timer <= 0) avgFramerate = (int) (1f / timelapse);
        fpscounter.text = string.Format(display,avgFramerate.ToString());
    }
}
