using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public float maxhealth;
    public float currentHealth;
    public GameManager gameManager;
    public Slider healthSlider;

    private bool isDead;
    private void Awake()
    {
        instance = this;
        healthSlider.maxValue = maxhealth;
        healthSlider.value = currentHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {

        currentHealth -= damage;
        if(currentHealth <= 0 && !isDead)
        {
            isDead = false;
            gameObject.SetActive(false);
            gameManager.gameOver();
        }
        healthSlider.value = currentHealth;
    }
}
