using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBoost : MonoBehaviour
{
    public float multiplier = 1.5f;
    public float duration = 8f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(speedPickup(other));
        }

    }

    IEnumerator speedPickup(Collider2D player)
    {
        Debug.Log("Speed Power up picked up!");

        // Apply effect to player
        Player speedBoost = player.GetComponent<Player>();
        speedBoost.speed *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // Wait x amount of seconds
        yield return new WaitForSeconds(duration);

        // Reverse effect on player
        speedBoost.speed /= multiplier;

        // Remove power up object
        Destroy(gameObject);
    }
}
 