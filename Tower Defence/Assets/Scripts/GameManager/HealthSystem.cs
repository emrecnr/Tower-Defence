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
    public static int rounds;
    void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        rounds = 0;
    }


   

    public void TakeDamage(int damageAmount)
    {
        maxHealth -= damageAmount; //caný hasar deðeri kadar azalt.

        healthSlider.value = maxHealth; // slider ýn deðerini cana eþitle.
        if (maxHealth <= 0)
        {
           // Destroy(gameObject);
        }

    }
}
