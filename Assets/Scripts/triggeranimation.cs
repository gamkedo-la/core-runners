using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeranimation : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Collider col1;
    public Collider col2;
    public Collider col3;

    public GameObject meteorite1;
    public GameObject meteorite2;
    public GameObject meteorite3;
    public GameObject Dustcollapse2;

           private void OnTriggerEnter(Collider other)
    {
    //do this properly so can have 1 or 2 drop and think about resetting after crash
    // can change values to weight probability of different collapses
    var rand = Random.Range(0f,3f);
    if (rand <=0){
    anim1.SetTrigger("triggercollapse");
    col1.enabled = true;
    meteorite1.SetActive(true);
    } else 
    if (rand <=3){
     col2.enabled = true;
    
     meteorite2.SetActive(true);
     StartCoroutine(Bridgecollapse());
    StartCoroutine(Dustcollapse());
    StartCoroutine(meteroritedestroy());

    } else
    anim3.SetTrigger("triggercollapse");
    col3.enabled = true;
     meteorite3.SetActive(true);
    }

    IEnumerator Dustcollapse()
    {
        yield return new WaitForSeconds(1.5f);
        Dustcollapse2.SetActive(true);
    }

    IEnumerator Bridgecollapse()
    {
        yield return new WaitForSeconds(1f);
       
        anim2.SetTrigger("triggercollapse");
    }

    IEnumerator meteroritedestroy()
    {
        yield return new WaitForSeconds(0.6f);
       meteorite2.SetActive(false);
        
    }
}
