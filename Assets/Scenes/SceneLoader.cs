using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update


    public void scena1(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void creditos()
    {
        SceneManager.LoadScene("endMenu");
    }
    public void exit()
    {
        
        Application.Quit();
    }

  
}
