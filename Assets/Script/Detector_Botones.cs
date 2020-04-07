using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector_Botones : MonoBehaviour
{   
    public bool canBePressed;
    public bool isDisappearing;
    public bool noteLost;
    public KeyCode keyToPress;
    Cambiar_Color cambiar;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent.tag=="Linea"){
            //transform.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            //En caso que logre oprimir el boton
            //El objeto desaparece y da un punto positivo
            if(canBePressed){
                cambiar.Punto();
                gameObject.SetActive(false);
                //Este if solo es para saber si el objeto va a ser desactivado
                isDisappearing=true;
                bool t;
                GameManager.instance.NoteHit(GameManager.instance.scorePerNote,t=false);
            }
        }
        //Este if es para las notas que no alcance a oprimir
        if(!isDisappearing && !canBePressed && noteLost){
            Debug.Log("--");
            isDisappearing=true;
            GameManager.instance.NoteMissed(GameManager.instance.badValueNoteLine );
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
            canBePressed=false;
            noteLost=true;
        }
    }
}
