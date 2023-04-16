using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public static HealthSystem instance;
    private void Awake()
    {
        instance = this;
    }
    public int maxHealth = 5;
    public Slider healthSlider;
    void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }


    void Update()
    {

    }

    public void TakeDamage(int damageAmount)
    {
        maxHealth -= damageAmount; //can� hasar de�eri kadar azalt.

        healthSlider.value = maxHealth; // slider �n de�erini cana e�itle.
        if (maxHealth <= 0)
        {
           // Destroy(gameObject);
        }

    }
}
