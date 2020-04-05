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
    public float currentScore;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;
    public Text scoreText;
    public Text multiText;
    public Slider barraDinero;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text="Score: 0";
        instance=this;
        changeValueSlider();
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying){
            if(Input.anyKeyDown){
                startPlaying=true;
                scroller.hasStarted=true;
                Invoke("PlayMusic",delayedTime);
            }
        }
        /*if(badNotes<=12){
            if(badNotes<=10){
                if(badNotes<=8){
                    if(badNotes<=6){
                        if(badNotes<=3){
                            if(badNotes<=0){
                                melody.volume=1f;
                            } else {
                                melody.volume=0.8f;
                            }                           
                        } else {
                            melody.volume=0.6f;
                        }                        
                    } else {
                        melody.volume=0.4f;
                    }                    
                } else {
                    melody.volume=0.2f;
                }                
            } else {
                melody.volume=0.001f;
            }
            
        }*/

    }
    public void NoteHit(float score){
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
        if(badNotes>0){
            badNotes--;
        }
    }
    public void NoteMissed(float score){
        Debug.Log("Nota Negativa");
        if(currentScore>0){
            currentScore-=negativeValueNote;
            scoreText.text="Score: "+currentScore;
        }
        changeValueSlider();
        badNotes++;
    }
    public void PlayMusic(){
        melody.Play();
        comping.Play();
    }
    public void changeValueSlider(){
        barraDinero.value=currentScore;
    }
}
