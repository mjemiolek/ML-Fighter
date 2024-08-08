using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] WalkingTriggerRight bool_script_right;
    [SerializeField] WalkingTriggerLeft bool_script_left;
    [SerializeField] WalkingTriggerRightEnemy bool_script_right_enemy;
    [SerializeField] WalkingTriggerLeftEnemy bool_script_left_enemy;
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
        if (bool_script_right_enemy.walkingColliderDetectorRightEnemy == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //allowed on combat action
                if (animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") || animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok"))
                {

                }
                else //not allowed on combat action
                {
                    Enemy.transform.Translate(-speed * Time.deltaTime, 0, 0);
                }
            }
        }

        if (bool_script_left_enemy.walkingColliderDetectorLeftEnemy == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //allowed on combat action
                if (animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") || animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok"))
                {

                }
                else //not allowed on combat action
                {
                    Enemy.transform.Translate(speed * Time.deltaTime, 0, 0);
                }
            }
        }

        if (bool_script_right.walkingColliderDetectorRight == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                //allowed on combat action
                if (animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") || animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok"))
                {

                }
                else //not allowed on combat action
                {
                    Player.transform.Translate(speed * Time.deltaTime, 0, 0);
                }
            }
        }

        if (bool_script_left.walkingColliderDetectorLeft == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                //allowed on combat action
                if (animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") || animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok"))
                {

                }
                else //not allowed on combat action
                {
                    Player.transform.Translate(-speed * Time.deltaTime, 0, 0);
                }
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
