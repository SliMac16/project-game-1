using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 5;
    public int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        healthBar.SetHealth(playerHealth);
    }
}
