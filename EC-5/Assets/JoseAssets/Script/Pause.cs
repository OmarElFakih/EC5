using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

  
}
