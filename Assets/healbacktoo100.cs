using UnityEngine;

public class healbacktoo100 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void HealToFull()
    {
        currentHealth = maxHealth;
    }

    void Die()
    {
        
        Destroy(gameObject);
    }

   
    void Update()
    {
        if (currentHealth <= 50)
        {
            HealToFull();
           
        }
    }
}
