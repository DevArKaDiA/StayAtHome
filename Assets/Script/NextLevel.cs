using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void PauseGame(int aux){
        Time.timeScale=aux;
    }
    public void RestartLevel(){
        Time.timeScale=1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Level(string levelName)
    {
        Time.timeScale=1;
        SceneManager.LoadScene(levelName);
    }
    public void Quitar(){
        Application.Quit();
    }
}
