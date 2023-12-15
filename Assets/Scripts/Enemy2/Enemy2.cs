using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public Transform player;
    public Animator animator;

    public float proximityThreshold = 5f;

    private bool isFlipped = false;
    private bool isPlayerAlive = true;

    public int maxHealth = 125;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (isPlayerAlive)
        {
            LookAtPlayer();

            if (IsPlayerClose())
            {
                RunTowardsPlayer();
            }
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public bool IsPlayerClose()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance < proximityThreshold;
    }

    public void RunTowardsPlayer()
    {
        animator.SetTrigger("RunTrigger");

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = (player.position - transform.position).normalized;

        float forceMultiplier = 4.5f;

        rb.velocity = direction * forceMultiplier;
    }

    public void PlayerDied()
    {
        isPlayerAlive = false;
        animator.SetTrigger("IdleTrigger");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        this.enabled = false;
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
        Debug.Log("Enemy2 died!");

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Enemy2>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.enabled = false;
        // StopAnimation();

        //  Destroy(animator);
       // GameObject[] all = gameObject.GetComponents<>();
    }


}
