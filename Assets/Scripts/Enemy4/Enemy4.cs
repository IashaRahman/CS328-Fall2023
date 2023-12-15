using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{

    public Transform player;
    public float speed = 0.01f;

    public float rotateSpeed = 0.00025f;

    private Rigidbody2D rb;

    public Animator animator;

    public GameObject arrow;

    public Transform firingPt;

    public float fireRate = 5f;
    public float fire = 0f;

    public float proximityThreshold = 5f;

    //private bool isFlipped = false;
    //private bool isPlayerAlive = true;

    public int maxHealth = 100;
    int currentHealth;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      //  firingPt = GetComponent<Transform>().fir;
        currentHealth = maxHealth;

    }

    private void Update()
    {
        if (player == null)
            getTarget();

        else
        {
            RotateToPlayer();
            if (fireRate <= fire)
                Fire();
        }
        
    }

    void Fire()
    {
        Instantiate(arrow, firingPt.position, firingPt.rotation);
        fire = 0f;
    }

    private void FixedUpdate()
    {
        fire += Time.deltaTime;
    }


    private void getTarget()
    {
        //GameObject temp;
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;

    }

    private void RotateToPlayer()
    {
        Vector2 tarDir = player.position - transform.position;
        float angle = Mathf.Atan2(tarDir.y, tarDir.x) * Mathf.Rad2Deg - 90f;

        Quaternion q = Quaternion.Euler(new Vector3(0,0,angle));

        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
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

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Boss1>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.enabled = false;
    }
}
