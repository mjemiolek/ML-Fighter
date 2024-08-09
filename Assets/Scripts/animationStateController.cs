using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
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
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
        punch = Input.GetKeyDown(KeyCode.J);
        block = Input.GetKeyDown(KeyCode.K);
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
