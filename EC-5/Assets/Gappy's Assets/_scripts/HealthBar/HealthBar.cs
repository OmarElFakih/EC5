using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [Header("UI elements")]
    public Image image;
    public GameObject GameOverUI;

    [Header("Data")]
    public float health;
    public Gradient gradient;
    public float volume = 0.45f;
    public AudioSource source;
    public AudioClip hurt;
    private float currentHealth, ratio;

    public Caronte player;
    public static bool gameIsOver = false;


    private void UpdateUI()
    {
        ratio = currentHealth / health;
        image.fillAmount = ratio;
        image.color = gradient.Evaluate(ratio);
    }

    private void InitializeData()
    {
        currentHealth = health;
        UpdateUI();
        gameIsOver = false;
    }

    private void TriggerGameOver()
    {

        //trigger gameOver

        CanvasManager.instance.ShowElements(4);
        MusicController.instance.ToGameover();
        player.enabled = false;
        gameIsOver = true;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        //check gameOver
        if (currentHealth <= 0) TriggerGameOver();

        //play other effects

        if(!source.isPlaying) source.PlayOneShot(hurt, volume);

    }

    // Start is called before the first frame update
    void Start() => InitializeData();

    // Update is called once per frame
    void Update() => UpdateUI();
}
