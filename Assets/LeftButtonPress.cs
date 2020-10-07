using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class LeftButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
 
public bool leftbuttonPressed;
 
public void OnPointerDown(PointerEventData eventData){
     leftbuttonPressed = true;
}
 
public void OnPointerUp(PointerEventData eventData){
    leftbuttonPressed = false;
}
}