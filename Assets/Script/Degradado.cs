using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Degradado : MonoBehaviour
{
    Image imagen;
    bool  on;
    public float speed;
    public GameObject son;
    private void Start() {
        imagen=GetComponent<Image>();
    }
    private void OnEnable() {
        on=true;
    }
    // Update is called once per frame
    void Update()
    {
        if(on){
            if(imagen.color.a>=1){
                son.SetActive(true);
            } else{
                Color aux;
                aux=imagen.color;
                aux.a+=speed;
                imagen.color=aux;
            }

        }
    }
}
