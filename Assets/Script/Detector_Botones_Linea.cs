using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detector_Botones_Linea : MonoBehaviour
{   
    public bool canBePressed;
    public bool isDisappearing;
    public bool noteLost;
    public KeyCode keyToPress;
    Cambiar_Color cambiar;
    Vector3 scaleChange;
    public Image silueta;
    public Color colorNoteHit;
    public Color colorNoteLost;
    public Image relleno;
    public Color colorRellenoHit;
    public Color colorRelllenoLost;
    bool aux;

    // Start is called before the first frame update
    void Start()
    {
        aux=true;
    }

    // Update is called once per frame
    void Update()
    {   
        /*if(canBePressed && !isDisappearing){
            aux=timeToPress/10;
            aux-=Time.deltaTime;
        }*/
        if(canBePressed){
            if(Input.GetKeyDown(keyToPress)){
                //En caso que logre oprimir el boton
                //El objeto desaparece y da un punto positivo
                if(canBePressed){
                    isDisappearing=true;
                }
            }

            if(Input.GetKeyUp(keyToPress)){
                canBePressed=false;
                cambiar.ColorOriginal();

                silueta.color=colorNoteLost;

            }else if(isDisappearing){
                if(Input.GetKey(keyToPress)){
                    cambiar.PuntoLargo();
                    /*scaleChange=transform.localScale;
                    scaleChange.x-=speed;
                    transform.localScale=scaleChange;*/
                    //Este if solo es para saber si el objeto va a ser desactivado
                    isDisappearing=true;
                    bool t;
                    GameManager.instance.NoteHit(GameManager.instance.scorePerNoteLine,t=false);
                    Debug.Log("Quitando");

                    silueta.color=colorNoteHit;
                    relleno.color=colorRellenoHit;
                    if(aux){
                        GameManager.instance.badNotes--;
                        aux=false;
                    }
                    //transform.Translate(Vector2.left*speed*10);
                }
            }
        }//Este if es para las notas que no alcance a oprimir
        else if(!isDisappearing && !canBePressed && noteLost){
            Debug.Log("--");
            GameManager.instance.NoteMissed(GameManager.instance.negativeValueNoteLine);
            noteLost=false;
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Activador"){
            cambiar=other.GetComponent<Cambiar_Color>();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Activador"){
            Debug.Log("Se Salio del Trigger");
            canBePressed=false;
            
            if(isDisappearing){
                noteLost=false;
            }
            isDisappearing=false;
            cambiar.ColorOriginal();
            ColorLost();
        }
    }
    public void ColorLost(){
        silueta.color=colorNoteLost;
        relleno.color=colorRelllenoLost;
    }
}
