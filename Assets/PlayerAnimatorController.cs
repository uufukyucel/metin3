using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void WalkAnim()
    {
        animator.SetBool("isRunning", true);
        animator.SetBool("isAttacking", false);
    }

    public void AttackAnim()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", true);
    }

    public void IdleAnim()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", false);
    }
}
