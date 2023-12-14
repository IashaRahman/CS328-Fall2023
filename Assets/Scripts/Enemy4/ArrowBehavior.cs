using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public float speed = 0.1f;

    public float Lifetime = 3;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, Lifetime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
}
