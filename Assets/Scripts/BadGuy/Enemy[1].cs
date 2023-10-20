using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public float attackSpeed = 1f; 
    protected GameObject player;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public abstract void Attack();

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}