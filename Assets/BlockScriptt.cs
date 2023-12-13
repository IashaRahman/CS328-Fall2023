using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector3 moveDirection;

    private void Update()
    {
        MoveBlock();
    }

    private void MoveBlock()
    {
        // Update the position of the block
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the block collides with the player
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                // Implement what happens when the block hits the player
                player.TakeDamage();
            }
        }
    }
}
