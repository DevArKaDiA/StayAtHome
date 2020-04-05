using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_Scroller : MonoBehaviour
{
    public float  beatTempo;
    public bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(hasStarted){
            transform.Translate(Vector2.left*beatTempo*Time.deltaTime);
        }
    }
}
