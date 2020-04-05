using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector_Botones_Linea : MonoBehaviour
{   
    public bool canBePressed;
    public bool isDisappearing;
    public bool noteLost;
    public KeyCode keyToPress;
    Cambiar_Color cambiar;
    public float speed;
    Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        }else if(transform.localScale.x<=0.1){
            gameObject.SetActive(false);
            cambiar.ColorOriginal();
        }
        if(canBePressed && isDisappearing){
            if(Input.GetKey(keyToPress)){
                cambiar.PuntoLargo();
                scaleChange=transform.localScale;
                scaleChange.x-=speed;
                transform.localScale=scaleChange;
                //Este if solo es para saber si el objeto va a ser desactivado
                isDisappearing=true;
                GameManager.instance.NoteHit();
                Debug.Log("Quitando");
                transform.Translate(Vector2.left*speed*10);
            }
        }
        //Este if es para las notas que no alcance a oprimir
        if(!isDisappearing && !canBePressed && noteLost){
            Debug.Log("--");
            GameManager.instance.NoteMissed();
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Activador"){
            canBePressed=true;
            cambiar=other.GetComponent<Cambiar_Color>();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Activador"){
            Debug.Log("Se Salio del Trigger");
            canBePressed=false;
            isDisappearing=false;
            noteLost=true;
        }
    }
}
