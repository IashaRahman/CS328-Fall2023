using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            healthPickup(other);
        }

    }

    void healthPickup(Collider2D player)
    {
        Debug.Log("Health Power up picked up!");

        // Apply effect to player
        Player healthBoost = player.GetComponent<Player>();
        healthBoost.currentHealth += 50;

        // Update the health bar
        player.GetComponent<Player>().healthBar.SetHealth(healthBoost.currentHealth);

        // Remove power up object
        Destroy(gameObject);
    }
}
