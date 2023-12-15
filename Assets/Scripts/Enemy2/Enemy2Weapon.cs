using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Weapon : MonoBehaviour
{
    public int attackDamage = 20;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public Player player;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            //Player player = colInfo.GetComponent<Player>();
            //if (player != null)
            //{
            player.TakeDamage();
            //}
          //  else
           // {
                Debug.LogWarning("Collider hit, but the object does not have a Player component.");
            //}
        }
        else
        {
            Debug.Log("No collider hit!");
        }
    }


    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
