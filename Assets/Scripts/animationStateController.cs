using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);
        bool punch = Input.GetKey(KeyCode.J);
        bool block = Input.GetKey(KeyCode.K);
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
