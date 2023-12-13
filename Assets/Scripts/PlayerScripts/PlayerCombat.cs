using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPointRight; // Attack point for facing right
    public Transform attackPointLeft;  // Attack point for facing left
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private Transform currentAttackPoint; // Reference to the current attack point

    void Start()
    {
        // Initialize the current attack point based on the initial direction
        currentAttackPoint = transform.localScale.x > 0 ? attackPointRight : attackPointLeft;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FlipAttackPoint();
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentAttackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Enemy1 enemy1Component = enemy.GetComponent<Enemy1>();
            Boss1 boss1Component = enemy.GetComponent<Boss1>();

            if (enemy1Component != null)
            {
                enemy1Component.TakeDamage(attackDamage);
            }
            else if (boss1Component != null)
            {
                boss1Component.TakeDamage(attackDamage);
            }
        }
    }

    void FlipAttackPoint()
    {
        // Flip the attack point based on the player's direction
        float playerDirection = Input.GetAxisRaw("Horizontal");

        if (playerDirection > 0)
            currentAttackPoint = attackPointRight;
        else if (playerDirection < 0)
            currentAttackPoint = attackPointLeft;
    }

    private void OnDrawGizmosSelected()
    {
        if (currentAttackPoint == null)
            return;

        Gizmos.DrawWireSphere(currentAttackPoint.position, attackRange);
    }
}
