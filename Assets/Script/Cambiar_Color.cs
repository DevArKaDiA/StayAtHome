using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cambiar_Color : MonoBehaviour
{
    public KeyCode keyToPress;
    public Image imageChildren;
    public Color colorPressed;
    Color auxColor;
    // Start is called before the first frame update
    void Start()
    {
        //imageChildren=GetComponentInChildren<Image>();
        auxColor=imageChildren.color;
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
}
