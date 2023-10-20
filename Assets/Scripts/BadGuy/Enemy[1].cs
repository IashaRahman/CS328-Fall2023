using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public float attackSpeed = 1f; 
    public GameObject player;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Attack()
    {

    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
            Die();
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}