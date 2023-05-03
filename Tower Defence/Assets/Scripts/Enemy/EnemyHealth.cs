using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    int maxHealth = 100;

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
        if (maxHealth <=0)
        {
            AddMoney();
            Die();
        }
    
    }

    public void Die()
    {
        Destroy(gameObject) ;
        WaveSpawner.enemiesAlive--;
    }

    public void AddMoney()
    {
        MoneySystem.money += 25;
    }
}
