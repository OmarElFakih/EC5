﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private bool debug;

    [Header("Highscore key")]
    public string key = "hs";

    [Header("User interface")]
    public Text scoreDisplay;
    public GameObject highScoredisplay;

    private int currentScore,highScore;
    private Animator anim;

    public void Add(int amount)
    {
        currentScore += amount;
        anim.SetTrigger("add");
        checkHighScore();
        updateUI();

    }

    private void updateUI()
    {
        //score display animation
        scoreDisplay.text = "Score: " + currentScore;        

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

    private void Start()
    {

        currentScore = 0;
        highScore = InitializeHighscore();
        anim = scoreDisplay.gameObject.GetComponent<Animator>();
        updateUI();

    }
}