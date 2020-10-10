using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class RightButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
 
public bool rightbuttonPressed;
 
public void OnPointerDown(PointerEventData eventData){
     rightbuttonPressed = true;
}
 
public void OnPointerUp(PointerEventData eventData){
    rightbuttonPressed = false;
}
}
