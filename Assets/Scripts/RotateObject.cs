using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public int BoostIncrease = 2;
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
            if (RacerMovement.currentBoostValue <10)
            RacerMovement.currentBoostValue += BoostIncrease;
            if (RacerMovement.currentBoostValue >10){
                RacerMovement.currentBoostValue = 10;
            }
            Destroy(this.gameObject);
        }
    }
}
