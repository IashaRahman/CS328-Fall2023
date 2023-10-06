using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spotting : MonoBehaviour
{

    private GameObject self;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedOBJ = collision.gameObject;
        if (collidedOBJ == player)
            Debug.Log("Yep");
    }

    
}
