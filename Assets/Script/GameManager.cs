using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource melody, comping;
    public float delayedTime;
    public float badNotes;
    public float goodNotes;
    public bool startPlaying;
    public Controlador_Scroller scroller;
    public static GameManager instance;
    public float scorePerNote;
    public float scorePerNoteLine;
    public float negativeValueNote;
    public float negativeValueNoteLine;
    public float currentScore;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;
    public float badMultiplier;
    public Text scoreText;
    public Text multiText;
    public Slider barraDinero;
    public bool aux;
    public GameObject panel;
    public GameObject win, lost;
    bool pause;
    BarraDinero barra;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text="Score: 0";
        instance=this;
        changeValueSlider();
        barra=barraDinero.gameObject.GetComponent<BarraDinero>();
    }

    // Update is called once per frame
    void Update()
    {
        //Pausa
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(pause){
                Debug.Log("PausaOff");
                Time.timeScale=1;
                panel.SetActive(false);
                PlayMusic();
            }else {
                Debug.Log("PausaOn");
                PauseMusic();
                Time.timeScale=0;
                panel.SetActive(true);
            }
            pause=!pause;

        }  
        //Comprobar si la musica ya termino
        if(!comping.isPlaying && Time.timeScale==1 && startPlaying){
            Time.timeScale=0;
            if(barraDinero.value>=barra.bien){
                win.SetActive(true);
            } else{
                lost.SetActive(true);
            }
        } 
        if(!startPlaying){
            if(Input.anyKeyDown){
                Time.timeScale=1;
                startPlaying=true;
                scroller.hasStarted=true;
                Invoke("PlayMusic",delayedTime);
            }
            else{
                Time.timeScale=0;
            }
        }
        //Bajar volumen por noob
        if(badNotes<=18)
        {
            if(badNotes<=16)
            {
                if(badNotes<=14)
                {
                    if(badNotes<=12)
                    {
                        if(badNotes<=8)
                        {
                            if(badNotes<=4)
                            {
                                if(badNotes<=0)
                                {
                                    melody.volume=1f;
                                } else {
                                    Debug.Log("1");
                                    melody.volume=0.8f;
                                    badMultiplier=1;
                                }                           
                            } else {
                                Debug.Log("0.6");
                                melody.volume=0.6f;
                                badMultiplier=5;
                            }                        
                        } else {
                            Debug.Log("0.4");
                            badMultiplier=5;
                            melody.volume=0.4f;
                        }                    
                    } else {
                        Debug.Log("0.2");
                        badMultiplier=10;
                        melody.volume=0.2f;
                    }                
                } else {
                    Debug.Log("0");
                    badMultiplier=15;
                    melody.volume=0.1f;
                }
            } else {
                    Debug.Log("0");
                    if(barraDinero.value<=barra.noTanMal){
                        melody.Stop();
                        comping.Stop();
                    }
                    badMultiplier=15;
                    melody.volume=0.05f;
            }
        }

    }
    public void NoteHit(float score,bool line){
        Debug.Log("Nota Positiva");
        /*if(currentMultiplier-1<multiplierThresholds.Length){
            multiplierTracker++;
            if(multiplierThresholds[currentMultiplier-1]<=multiplierTracker){
                multiplierTracker=0;
                currentMultiplier++;
            }
        }*/
        //multiText.text="Multiplier: x"+currentMultiplier;
        currentScore+=score;
        scoreText.text="Score: "+currentScore;
        changeValueSlider();
        if(badNotes>0 && line){
            badNotes--;
        }
    }
    public void NoteMissed(float negativescore){
        Debug.Log("Nota Negativa");
        if(currentScore>0){
            currentScore-=negativescore*badMultiplier;
            scoreText.text="Score: "+currentScore;
        }
        changeValueSlider();
        badNotes++;
    }
    public void PlayMusic(){
        melody.Play();
        comping.Play();
    }
    public void PauseMusic(){
        melody.Pause();
        comping.Pause();
    }
    public void changeValueSlider(){
        barraDinero.value=currentScore;
    }
}
