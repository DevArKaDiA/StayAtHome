using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarMusica : MonoBehaviour
{   
    AudioSource audio;
    public float retrasar;
    private void Start() {
        audio=GetComponent<AudioSource>();
    }
    private void OnEnable() {
        Invoke("Reproducir",retrasar);
    }
    public void Reproducir(){
        audio.Play();
    }
}
