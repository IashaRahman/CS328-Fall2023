using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 direction;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Handle what happens when the arrow hits something
        Debug.Log("Arrow hit: " + other.name);
        Destroy(gameObject); // Destroy the arrow on impact
    }
}
