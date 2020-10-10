using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class BoostButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
 
public bool boostbuttonPressed;
 
public void OnPointerDown(PointerEventData eventData){
     boostbuttonPressed = true;
}
 
public void OnPointerUp(PointerEventData eventData){
    boostbuttonPressed = false;
}
}
