using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPointRight;
    public Transform attackPointLeft;
    public LayerMask enemyLayers;

    public float attackRange = 1f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private Transform currentAttackPoint;
    private bool isBlocking = false;

    void Start()
    {
        currentAttackPoint = transform.localScale.x > 0 ? attackPointRight : attackPointLeft;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            // Check for attack input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FlipAttackPoint();
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }

            // Check for block input
            if (Input.GetKeyDown(KeyCode.B))
            {
                Block();
            }
            else if (Input.GetKeyUp(KeyCode.B))
            {
                StopBlocking();
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentAttackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            // Damage calculation based on blocking
            int damageToDeal = isBlocking ? attackDamage / 2 : attackDamage;

            Enemy1 enemy1Component = enemy.GetComponent<Enemy1>();
            Boss2 boss2Component = enemy.GetComponent<Boss2>();
            Enemy2 enemy2Component = enemy.GetComponent<Enemy2>();
            Enemy3 enemy3Component = enemy.GetComponent<Enemy3>();
            Enemy4 enemy4Component = enemy.GetComponent<Enemy4>();

            if (enemy1Component != null)
            {
                enemy1Component.TakeDamage(damageToDeal);
            }
            else if (boss2Component != null)
            {
                boss2Component.TakeDamage(damageToDeal);
            }
            else if (enemy2Component != null)
            {
                enemy2Component.TakeDamage(damageToDeal);
            }
            else if (enemy3Component != null)
            {
                enemy3Component.TakeDamage(damageToDeal / 2);
            }
            else if (enemy4Component != null)
            {
                enemy4Component.TakeDamage(damageToDeal);
            }
        }
    }

    void FlipAttackPoint()
    {
        float playerDirection = Input.GetAxisRaw("Horizontal");

        if (playerDirection > 0)
            currentAttackPoint = attackPointRight;
        else if (playerDirection < 0)
            currentAttackPoint = attackPointLeft;
    }

    void Block()
    {
        isBlocking = true;
        animator.SetBool("Block", true);
    }

    void StopBlocking()
    {
        isBlocking = false;
        animator.SetBool("Block", false);
    }

    private void OnDrawGizmosSelected()
    {
        if (currentAttackPoint == null)
            return;

        Gizmos.DrawWireSphere(currentAttackPoint.position, attackRange);
    }
}
