using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public int BoostIncrease = 5;
    public float rotationSpeed;
    void Update()
    {
        this.transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Racer")
        {
            print("Contact");
            RacerMovement.currentBoostValue += BoostIncrease;
            Destroy(this.gameObject);
        }
    }
}
