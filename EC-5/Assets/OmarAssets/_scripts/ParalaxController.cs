using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxController : MonoBehaviour
{

    public FreeParallax paralax;
    public float gameplaySpeed;
    public float menuSpeed;
    public float lerpT;

    private float targetSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator Transition(bool toGameplay)
    {
        targetSpeed = toGameplay ? gameplaySpeed : menuSpeed;

        while (paralax.Speed != targetSpeed)
        {
            paralax.Speed = Mathf.Lerp(paralax.Speed, targetSpeed, lerpT * Time.deltaTime);
            yield return null;
        }
    }


    public void GoToGameplay()
    {
        if (MusicController.instance != null)
        {
            MusicController.instance.ToGameplay();
        }

        StartCoroutine(Transition(true));
    }

    public void GameOver()
    {
        StartCoroutine(Transition(false));
    }
}
