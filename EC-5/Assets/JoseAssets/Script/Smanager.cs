using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Smanager : MonoBehaviour
{
 
    //gameplay=3,credits=4
    public void ChangeScenes(int index)
    {
        SceneManager.LoadScene(index);
    }
}
