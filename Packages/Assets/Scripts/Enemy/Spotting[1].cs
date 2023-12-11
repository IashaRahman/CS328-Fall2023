using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotting : MonoBehaviour
{
    public GameObject player;
    public float attackSpeed = 5f;
    public bool isSpotted = false; 

    private bool isAttacking = false;

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, attackSpeed * Time.deltaTime);
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
                //Get rekt scrub
                Destroy(player);
            }
            else
            {
                // Taking any damage.
                Debug.Log("Player has taken damage!");
            }
            isAttacking = true;
        }
    }
}