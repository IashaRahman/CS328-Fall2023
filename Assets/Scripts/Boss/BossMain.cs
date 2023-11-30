using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossMain : MonoBehaviour
{


    //public TextMeshProUGUI countText;
    //public GameObject instruct;
    //public GameObject winTextObject;
    private Rigidbody2D rb;
    public Sprite[] Attack;

    public SpriteRenderer spriteRenderer;

    public Move playerRef;

    public int health = 100;

    //private bool jump;
    //private bool isGrounded;

    //	public float jumpCount = 0;
    private float movementX;
    private float movementY;
    //private float movementZ = 0.0f;
    public float speed;
    //private int count;
    void Start()
    {
        //jump = false;
        //isGrounded = true;
        rb = GetComponent<Rigidbody2D>();
        //	for(int i=0;i<4;i++)
        //	img[i] = new SpriteRenderer(/Assets/ImportCrap/)

        //count = 0;


        //winTextObject.SetActive(false);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ChangeSprite();
    }

   


    public void Attacked()
    {
        health -= 5;
        if (health <= 0)
            Debug.Log("Died");
    }
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX, movementY);

        //jump = false;
        //rb.AddForce(movement * speed);
        rb.MovePosition(rb.position + movement);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
      
        Debug.Log("Coliided");
        if (collision.gameObject.tag == "Player")
        {
            ChangeSprite();
            Swing();
        }
    }

    private void ChangeSprite()
    {
        spriteRenderer.sprite = Attack[0];
    }

    private void Swing()
    {
        playerRef.Attacked();
    }


}
