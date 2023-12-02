using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    // Update is called once per frame
    void Start()
    {
        currentHealth = maxHealth;

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<BadGuyPatrol>().enabled = false;
        this.enabled = false;

        BadGuyPatrol badGuyPatrolScript = GetComponent<BadGuyPatrol>();

        if (badGuyPatrolScript != null)
        {
            badGuyPatrolScript.enabled = false;

            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}

