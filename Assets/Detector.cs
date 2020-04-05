using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    Detector_Botones_Linea detectorBotones;
    private void Start() {
       detectorBotones=gameObject.GetComponentInParent(typeof(Detector_Botones_Linea)) as Detector_Botones_Linea;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Activador"){
            Debug.Log("EntroBoton");
        }
        
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag=="Activador"){
            detectorBotones.canBePressed=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Activador" && detectorBotones.isDisappearing==false){
            detectorBotones.canBePressed=false;
            detectorBotones.noteLost=true;
            detectorBotones.ColorLost();
        }
    }
}
