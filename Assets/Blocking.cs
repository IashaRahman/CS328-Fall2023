using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public bool isBlocking = false;
    public KeyCode blockKey = KeyCode.B; // The key to press for blocking, change as needed

    void Update()
    {
        // Check if the block key is pressed
        if (Input.GetKeyDown(blockKey))
        {
            StartBlocking();
        }

        // Check if the block key is released
        if (Input.GetKeyUp(blockKey))
        {
            StopBlocking();
        }
    }

    void StartBlocking()
    {
        isBlocking = true;
        // You can add animations or other effects here
        Debug.Log("Blocking started");
    }

    void StopBlocking()
    {
        isBlocking = false;
        // You can add animations or other effects here
        Debug.Log("Blocking stopped");
    }

    // This function can be used to handle incoming attacks
    public void ReceiveAttack()
    {
        if (isBlocking)
        {
            Debug.Log("Attack blocked!");
            // Handle the blocked attack (reduce damage, trigger effects, etc.)
        }
        else
        {
            Debug.Log("Attack hits!");
            // Handle the successful attack
        }
    }
}
