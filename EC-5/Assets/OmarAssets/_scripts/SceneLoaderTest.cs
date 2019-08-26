using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderTest : MonoBehaviour
{

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void transition()
    {
        MusicController.instance.ToGameplay();
    }

}
