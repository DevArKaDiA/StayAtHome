using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] objectos;
    int i=0;
    private void Awake() {
        Time.timeScale=0;
    }

    private void Update() {
        if(Input.anyKeyDown){
            if(i<=objectos.Length){
                if(i==0){
                    Debug.Log("Un Objeto: "+i);
                    objectos[i].SetActive(true);
                    i++;
                }else if(i==1){
                    objectos[1].SetActive(true);
                    objectos[0].SetActive(false);
                    i++;

                }else if(i==2) {
                    objectos[2].SetActive(true);
                    objectos[1].SetActive(false);
                    i++;
                }
                else if(i==3) {
                    objectos[3].SetActive(true);
                    objectos[2].SetActive(false);
                    gameObject.SetActive(false);
                }
                
                
            }
        }
    }
}
