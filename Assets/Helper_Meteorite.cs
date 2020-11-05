using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper_Meteorite : MonoBehaviour
{
   
    [SerializeField] private Transform startmeteorite;
    [SerializeField] private Transform hitpoint;

    [SerializeField] private GameObject meteroite;
    [SerializeField] private GameObject groundhit;


      // Movement speed in units per second.
    public float speed = 1.0f;
    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    // Need to set Start Rotation of particle systems based on angle of vector between startmeteroirt and hitpoint gameobjects
    // Need to carry meteroite particles past point of hit for short period so get gradual fade out of trail, then kill gameobject
    // Otherwise will get trail dissapearing instantly?
    // Trigger groundhit at point of meteroite impact
    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startmeteorite.position, hitpoint.position);
    }

    
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        meteroite.transform.position = Vector3.Lerp(startmeteorite.position, hitpoint.position, fractionOfJourney);
        
        //meteroite.transform.position = Vector3.Lerp(startmeteorite.position, hitpoint.position, 0.01f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startmeteorite.position, hitpoint.position);
        Gizmos.DrawSphere(startmeteorite.position, 4);
        Gizmos.DrawCube( hitpoint.position, new Vector3 ( 4,1,4));
    }

}
