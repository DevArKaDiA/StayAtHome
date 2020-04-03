using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    AudioSource music;
    public bool startPlaying;
    public Controlador_Scroller scroller;
    public static GameManager instance;
    public int scorePerNote;
    public int currentScore;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;
    public Text scoreText;
    public Text multiText;
    public float delayedTime;
    // Start is called before the first frame update
    void Start()
    {
        music=GetComponent<AudioSource>();
        scoreText.text="Score: 0";
        instance=this;
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
    }
    public void NoteHit(){
        Debug.Log("Nota Positiva");
        if(currentMultiplier-1<multiplierThresholds.Length){
            multiplierTracker++;
            if(multiplierThresholds[currentMultiplier-1]<=multiplierTracker){
                multiplierTracker=0;
                currentMultiplier++;
            }
        }
        multiText.text="Multiplier: x"+currentMultiplier;
        currentScore+=scorePerNote*currentMultiplier;
        scoreText.text="Score: "+currentScore;
    }
    public void NoteMissed(){
        Debug.Log("Nota Negativa");
    }
    public void PlayMusic(){
        music.Play();
    }
}
