using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyPatrol : MonoBehaviour
{

    public GameObject SpotZone;
    public Transform[] target;
    public float speed;
    public Rigidbody2D rb;
    public Vector3 dir, heading;
    float distance;

    private int current = 0;    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Vector3.Distance(rb.position, target[current].position) >= 0.5f)
        {
            heading = target[current].position - transform.position;
            heading.z = 0;
            dir = heading.normalized;

            rb.velocity = dir * speed;
        }
        else
        {
            current = (current + 1) % target.Length;
            rb.velocity = Vector2.zero; 
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
