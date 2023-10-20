using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    public float attackRange = 1.5f;

    public Move temp;

    public override void Start()
    {
        base.Start();
    }
    
    public void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
            
            Debug.Log("Melee attack!");
            temp.Attacked();
        }
    }
}
