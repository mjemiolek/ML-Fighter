using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMechanic : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int currentHealthEnemy;
    public HealthBar healthBar;
    public HealthBar healthBarEnemy;
    public GameObject Player;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentHealthEnemy = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBarEnemy.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//for test
        {
            TakeDamage(20);
            TakeDamageEnemy(20);
        }

        if (Input.GetKeyDown(KeyCode.J) && Player.GetComponent<PlayerBehaviour>().punchArea == true)//for test
        {
            Debug.Log("hit");
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    void TakeDamageEnemy(int damage)
    {
        currentHealthEnemy -= damage;

        healthBarEnemy.SetHealth(currentHealthEnemy);
    }
}
