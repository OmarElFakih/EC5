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
    public AudioMixerSnapshot gameover;

    public AudioSource a_menu;
    public AudioSource a_gameplay;
    public AudioSource a_gameover;

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
        a_menu.Play();
        //StartCoroutine(AudioStopper(a_gameover));
        Debug.Log("scene loaded");
    }

    public void ToGameplay()
    {
        gameplay.TransitionTo(transitionSeconds);
        a_gameplay.Play();
        StartCoroutine(AudioStopper(a_menu));
    }

    public void ToGameover()
    {
        gameover.TransitionTo(transitionSeconds);
        a_gameover.Play();
        StartCoroutine(AudioStopper(a_gameplay));
    }

    IEnumerator AudioStopper(AudioSource source)
    {
        yield return new WaitForSeconds(transitionSeconds + .5f);
        source.Stop();
    }

}
