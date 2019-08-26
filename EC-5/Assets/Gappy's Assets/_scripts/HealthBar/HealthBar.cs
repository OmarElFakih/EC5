using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [Header("UI elements")]
    public Image image;

    [Header("Data")]
    public float health;
    public Gradient gradient;
    private float currentHealth, ratio;

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
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        //play effects
        //play other effects
    }

    // Start is called before the first frame update
    void Start() => InitializeData();

    // Update is called once per frame
    void Update() => UpdateUI();
}
