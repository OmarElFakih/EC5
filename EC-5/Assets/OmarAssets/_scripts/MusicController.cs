using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    public static MusicController instance = null;

    public AudioMixerSnapshot menu;
    public AudioMixerSnapshot gameplay;
    public float transitionSeconds;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        /*Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);*/
        menu.TransitionTo(transitionSeconds);

        Debug.Log("scene loaded");
    }

    public void ToGameplay()
    {
        gameplay.TransitionTo(transitionSeconds);
    }

}
