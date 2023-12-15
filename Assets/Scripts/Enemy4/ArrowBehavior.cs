using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public float speed = 0.1f;

    public float Lifetime = 3;

    private Rigidbody2D rb;

    public Player player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, Lifetime);
        player = GameObject.FindAnyObjectByType<Player>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject = player.gameObject)
            player.TakeDamage();

        Destroy(this);
    }
}
