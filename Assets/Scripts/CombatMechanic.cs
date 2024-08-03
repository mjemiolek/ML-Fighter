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
    public animationStateController animatorscript;
    public enemyAnimationStateController animatorscriptEnemy;
    public float speed;
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") || animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("blok"))
            {
                //allowed on action
            }
            else
            {
                //not allowed on action
                Enemy.transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") || animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("blok"))
            {
                //allowed on action
            }
            else
            {
                //not allowed on action
                Enemy.transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }


        if (Input.GetKey(KeyCode.A))
        {
            if (animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") || animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok"))
            {
                //allowed on action
            }
            else
            {
                //not allowed on action
                Player.transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") || animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok"))
            {
                //allowed on action
            }
            else
            {
                //not allowed on action
                Player.transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))//for test
        {
            TakeDamage(20);
            TakeDamageEnemy(20);
        }

        if (Input.GetKey(KeyCode.J) && Player.GetComponent<PlayerBehaviour>().punchArea == true && animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") == false)//for test
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
