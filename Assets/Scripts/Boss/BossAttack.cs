using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    public float speed = 2.0f;
    public float attackRange = 3.0f;

    private Transform player;
    private Rigidbody2D rb;
    private Boss1 boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss1>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player != null)
        {
            boss.LookAtPlayer();

            if (Vector2.Distance(player.position, rb.position) <= attackRange)
            {
                animator.SetTrigger("Attack");
            }
            else
            {
                Vector2 target = new Vector2(player.position.x, rb.position.y);
                Vector2 newPosition = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
                rb.MovePosition(newPosition);
            }
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}