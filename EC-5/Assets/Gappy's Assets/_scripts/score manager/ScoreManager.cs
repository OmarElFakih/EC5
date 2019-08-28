using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private bool debug = false;

    [Header("Highscore key")]
    public string key = "hs";

    [Header("User interface")]
    public Text scoreDisplay;
    public GameObject highScoredisplay;
    public Text lastDisplay;

    [Header("bonus score")]
    public int bonus = 10;
    public float timeInterval = 5.5f;
    private float ini;


    private int currentScore,highScore;
    private Animator anim;

    public void Add(int amount)
    {
        currentScore += amount;
        anim.SetTrigger("add");
        updateUI();

    }

    private void updateUI()
    {
        //score display animation
        scoreDisplay.text = "Score: " + currentScore;
        lastDisplay.text = "Final Score: " + currentScore;

    }

    private void checkHighScore()
    {

        if (highScore < currentScore)
        {
            PlayerPrefs.SetInt(key, currentScore);
            if (!highScoredisplay.activeSelf) highScoredisplay.SetActive(true);
        }

    }

    private int InitializeHighscore()
    {
        if (debug)
        {
            PlayerPrefs.SetInt(key, 0);
            return 0;
        }
        else return PlayerPrefs.GetInt(key,0);

    }

    private void AddBonus()
    {
        if (timeInterval <= 0)
        {
            currentScore += bonus;
            anim.SetTrigger("add");
            updateUI();
            timeInterval = ini;
        }
        else timeInterval -= Time.deltaTime;

    }

    private void Start()
    {
        currentScore = 0;
        highScore = InitializeHighscore();
        ini = timeInterval;
        anim = scoreDisplay.gameObject.GetComponent<Animator>();
        updateUI();

    }

    private void FixedUpdate()
    {
        AddBonus();
        checkHighScore();

    }
}
