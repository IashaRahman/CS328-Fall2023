using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;

    void Update()
    {
        if (player != null)
        {
            
            float distance = Vector2.Distance(transform.position, player.position);
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
}
