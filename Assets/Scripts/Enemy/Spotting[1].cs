using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotting : MonoBehaviour
{
    public Transform player;
    public GameObject enemyTypeToCall;
    public Util util = new Util();


    public Animator animator;

    public float proximityThreshold = 4f;

    private bool isFlipped = false;
    private bool isPlayerAlive = true;

    public int maxHealth = 10;
    int currentHealth;
    public float attackSpeed = 5f;
    public bool isSpotted = false; 

    private bool isAttacking = false;

    bool alreadyCalled = false;

    void Start()
    {
        currentHealth = maxHealth;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerClose() && isSpotted)
        {
 
                isAttacking = true;
                isSpotted = false;
 
        }

        if (isPlayerAlive && isSpotted)
        {
            LookAtPlayer();

            if (IsPlayerClose())
            {
                RunTowardsPlayer();
            }
        }
    }

    // 
    public void SpotNPC()
    {
        isSpotted = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedOBJ = collision.gameObject;
            if (collidedOBJ == player)
            {   
                if (!isSpotted)
                {
                    isAttacking = true;
                    isSpotted = false;
                    CallPeeps();
                }

            }
        

        else if (isAttacking)
        {
            
        }
    }

    private void CallPeeps()
    {
        util.CallReinforcements(2, enemyTypeToCall);
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
        Debug.Log("Boss1 died!");

        animator.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Boss1>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.enabled = false;
    }

}