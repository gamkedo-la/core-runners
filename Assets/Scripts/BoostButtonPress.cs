using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class BoostButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
 
public bool boostbuttonPressed;
 
public void OnPointerDown(PointerEventData eventData){
     boostbuttonPressed = true;

        GameObject.Find("Racer").GetComponent<EngineSoundSpeed>().Flip();
}
 
public void OnPointerUp(PointerEventData eventData){
    boostbuttonPressed = false;

        GameObject.Find("Racer").GetComponent<EngineSoundSpeed>().Flip();

    }
}
