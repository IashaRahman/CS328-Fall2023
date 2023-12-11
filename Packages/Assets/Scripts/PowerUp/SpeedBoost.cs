using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{

    private Collider2D rb;
   // public GameObject player;
    public Player playerMove;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Coliided");
        if (collision.gameObject.tag == "Player")
        {
            playerMove.speed *= 2;
            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triggerCollide");
        if (collision.gameObject.tag == "Player")
        {
            playerMove.speed *= 2;
            Destroy(this);
        }
    }
}
