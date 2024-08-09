using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;

public class CombatMechanic : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int currentHealthEnemy;
    public HealthBar healthBar;
    public HealthBar healthBarEnemy;
    public GameObject Player;
    public GameObject Enemy;
    public GameObject playerPunch;
    public GameObject enemyPunch;
    public animationStateController animatorscript;
    public enemyAnimationStateController animatorscriptEnemy;
    public float speed;
    [SerializeField] WalkingTriggerRight bool_script_right;
    [SerializeField] WalkingTriggerLeft bool_script_left;
    [SerializeField] WalkingTriggerRightEnemy bool_script_right_enemy;
    [SerializeField] WalkingTriggerLeftEnemy bool_script_left_enemy;

    private bool playerBool = true;
    private bool enemyBool = true;
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
        //walking scripts
        if (bool_script_right_enemy.walkingColliderDetectorRightEnemy == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") == false
                    && animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false)
                {
                    Enemy.transform.Translate(-speed * Time.deltaTime, 0, 0);
                }
            }
        }

        if (bool_script_left_enemy.walkingColliderDetectorLeftEnemy == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") == false
                    && animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false)
                {
                    Enemy.transform.Translate(speed * Time.deltaTime, 0, 0);
                }
            }
        }

        if (bool_script_right.walkingColliderDetectorRight == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") == false
                    && animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false)
                {
                    Player.transform.Translate(speed * Time.deltaTime, 0, 0);
                }
            }
        }

        if (bool_script_left.walkingColliderDetectorLeft == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") == false
                    && animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false)
                {
                    Player.transform.Translate(-speed * Time.deltaTime, 0, 0);
                }
            }
        }
        //end of walking scripts


        if (Input.GetKeyDown(KeyCode.Space))//for test
        {
            TakeDamage(20);
            TakeDamageEnemy(20);
        }

        //combat system
        if (Input.GetKeyDown(KeyCode.J)
            && playerPunch.GetComponent<PlayerBehaviour>().punchArea == true
            && animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") == false
            && animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false
            && playerBool == true
            && animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false)
        {
            TakeDamageEnemy(10);
            playerBool = false;
            StartCoroutine(playerBoolChange());
        }

        if (Input.GetKeyDown(KeyCode.Keypad5)
            && enemyPunch.GetComponent<EnemyBehaviour>().punchArea == true
            && animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") == false
            && animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false
            && enemyBool == true
            && animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false)
        {
            TakeDamage(10);
            enemyBool = false;
            StartCoroutine(enemyBoolChange());
        }
        //end of combat system
    }

    IEnumerator playerBoolChange()
    {
        yield return new WaitForSeconds(0.5f);
        playerBool = true;
    }

    IEnumerator enemyBoolChange()
    {
        yield return new WaitForSeconds(0.5f);
        enemyBool = true;
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
