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
    public bool playerHitted = false;
    public bool enemyHitted = false;

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
        //if (Input.GetKey(KeyCode.RightArrow)) EnemyRight();
        //if (Input.GetKey(KeyCode.LeftArrow)) EnemyLeft();
        if (Input.GetKey(KeyCode.D)) PlayerRight();
        if (Input.GetKey(KeyCode.A)) PlayerLeft();
        //end of walking scripts

        //combat system
        if (Input.GetKeyDown(KeyCode.J)) PlayerPunch();
        //if (Input.GetKeyDown(KeyCode.Keypad5)) EnemyPunch();
        //end of combat system

        if (Input.GetKeyDown(KeyCode.Space))//for test
        {
            TakeDamage(20);
            TakeDamageEnemy(20);
        }

        //if( currentHealth <= 0 || currentHealthEnemy <= 0)
        //{
        //    restart();
        //}
    }

    public void EnemyLeft()
    {
        if (bool_script_left_enemy.walkingColliderDetectorLeftEnemy == false)
        {
            if (animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") == false
                && animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false)
            {
                Enemy.transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }
    }

    public void EnemyRight()
    {
        if (bool_script_right_enemy.walkingColliderDetectorRightEnemy == false)
        {
            if (animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") == false
                && animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false)
            {
                Enemy.transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }
    }

    public void PlayerLeft()
    {
        if (bool_script_left.walkingColliderDetectorLeft == false)
        {

            if (animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") == false
                && animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false)
            {
                Player.transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }
    }

    public void PlayerRight()
    {
        if (bool_script_right.walkingColliderDetectorRight == false)
        {

            if (animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") == false
                && animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false)
            {
                Player.transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }
    }

    public void EnemyPunch()
    {
        if (enemyPunch.GetComponent<EnemyBehaviour>().punchArea == true
            && animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") == false
            && animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false
            && enemyBool == true
            && animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false)
        {
            TakeDamage(10);
            enemyBool = false;
            StartCoroutine(enemyBoolChange());
        }
    }

    public void PlayerPunch()
    {
        if (playerPunch.GetComponent<PlayerBehaviour>().punchArea == true
            && animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("cios") == false
            && animatorscript.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false
            && playerBool == true
            && animatorscriptEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("blok") == false)
        {
            TakeDamageEnemy(10);
            playerBool = false;
            StartCoroutine(playerBoolChange());
        }
    }

    public void EnemyBlock()
    {
        animatorscriptEnemy.block = true;
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
        playerHitted = true;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    void TakeDamageEnemy(int damage)
    {
        enemyHitted = true;
        currentHealthEnemy -= damage;
        healthBarEnemy.SetHealth(currentHealthEnemy);
    }


    //restart mechanic
    public void restart()
    {
        Player.transform.localPosition = new Vector3(-6f, -5f, 0f);
        Enemy.transform.localPosition = new Vector3(5f, -5f, 0f);
        currentHealth = maxHealth;
        currentHealthEnemy = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBarEnemy.SetMaxHealth(maxHealth);
    }
}