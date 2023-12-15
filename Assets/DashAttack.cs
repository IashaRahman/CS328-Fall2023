using System.Collections;
using UnityEngine;

public class BossDashAttack : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashTime = 0.5f;
    public float dashCooldown = 5f;  // Set the cooldown to 5 seconds

    private bool isDashing = false;

    // Assuming you have a reference to the player transform
    public Transform playerTransform;

    void Start()
    {
        // Start the coroutine for continuous dashing
        StartCoroutine(DashRoutine());
    }

    IEnumerator DashRoutine()
    {
        while (true)
        {
            // Wait for the cooldown period
            yield return new WaitForSeconds(dashCooldown);

            // Perform the dash attack
            if (!isDashing)
            {
                StartCoroutine(Dash());
            }
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        Vector3 startPos = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < dashTime)
        {
            
            transform.position = Vector3.Lerp(startPos, playerTransform.position, elapsedTime / dashTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

       
        transform.position = playerTransform.position;

        isDashing = false;
    }
}
