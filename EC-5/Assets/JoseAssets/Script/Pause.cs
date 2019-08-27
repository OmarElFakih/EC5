using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    
    public bool paused;
    
  public void stopGame()
    {
        if (!paused)
        {
            Time.timeScale = 0;
        }
        else
        {
           
            Time.timeScale = 1;
        }
        paused = !paused;
    }

    public void exitGame()
    {
        stopGame();
        SceneManager.LoadScene(1);
    }
  
}
