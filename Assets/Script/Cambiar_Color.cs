using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cambiar_Color : MonoBehaviour
{
    public KeyCode keyToPress;
    public Image imageChildren;
    public Color colorPressed;
    Color auxColor, auxColorBoton;
    public Image botonPunto;
    public Color colorPunto;
    // Start is called before the first frame update
    void Start()
    {
        //imageChildren=GetComponentInChildren<Image>();
        auxColor=imageChildren.color;
        auxColorBoton=botonPunto.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            imageChildren.color=colorPressed;
        }
        if(Input.GetKeyUp(keyToPress)){
            imageChildren.color=auxColor;
        }
    }
    public void Punto(){
        botonPunto.color=colorPunto;
        Invoke("ColorOriginal",0.3f);
    }
    public void PuntoLargo(){
        botonPunto.color=colorPunto;
    }
    public void ColorOriginal(){
        botonPunto.color=auxColorBoton;
    }
}
