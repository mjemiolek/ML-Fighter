using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimationStateController : MonoBehaviour
{
    public Animator animator;
    public bool left;
    public bool right;
    public bool punch;
    public bool block;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        left = Input.GetKey(KeyCode.RightArrow);
        right = Input.GetKey(KeyCode.LeftArrow);
        punch = Input.GetKeyDown(KeyCode.Keypad5);
        block = Input.GetKeyDown(KeyCode.Keypad6);
        if (left)
        {
            animator.SetBool("isWalkingLeft", true);
        }
        if (right)
        {
            animator.SetBool("isWalkingRight", true);
        }
        if (punch)
        {
            animator.SetBool("isPunching", true);
        }
        if (block)
        {
            animator.SetBool("isBlocking", true);
        }

        if (!left)
        {
            animator.SetBool("isWalkingLeft", false);
        }
        if (!right)
        {
            animator.SetBool("isWalkingRight", false);
        }
        if (!punch)
        {
            animator.SetBool("isPunching", false);
        }
        if (!block)
        {
            animator.SetBool("isBlocking", false);
        }
    }
}
