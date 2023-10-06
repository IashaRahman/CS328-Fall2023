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
            //  Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            // Vector2 pos2D = new Vector2(rb.position.x - target[current].transform.position.x, rb.position.y - target[current].transform.position.y);


            //Vector3.MoveTowards(rb.position, target[current].position, speed );
            // Vector2 heading = new Vector2(target[current].position.x - rb.position.x, target[current].position.y - rb.position.y);
            heading = target[current].position - transform.position;
            heading.z = 0;
            distance = heading.magnitude;
            dir = heading / distance;

            // GameObject.Dire
            rb.transform.Translate(dir * speed * Time.deltaTime);

         //   GetComponent<Rigidbody2D>().MovePosition(pos);
        }
        else //if (transform.position.x == target[current].position.x && this.transform.position.y == target[current].position.y)
            current = (current + 1) % target.Length;

        //Debug.Log("Tar Pos: " + target[current].position);
        //Debug.Log("Tar: " + target[current]);
        // Debug.Log("Current Pos: " + rb.transform.position);

    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
