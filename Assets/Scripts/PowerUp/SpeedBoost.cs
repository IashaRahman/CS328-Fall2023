using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBoost : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            speedPickup(other);
        }

    }

    void speedPickup(Collider2D player)
    {
        Debug.Log("Speed Power up picked up!");

        // Apply effect to player
        Player playerScript = player.GetComponent<Player>();

        // Need speed variable

        // Remove power up object
        Destroy(gameObject);
    }
}
 