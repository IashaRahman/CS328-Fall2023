using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BossMain : MonoBehaviour
{

    /*
     * !!!!!!!!!
     * IF GETTING REFERENCE TO OBJECT NOT SET 
     * ATTACH PLAYER'S MOVE SCRIPT TO PLAYER REFERENCE
     * !!!!!!!!!
     */


    //public TextMeshProUGUI countText;
    //public GameObject instruct;
    //public GameObject winTextObject;
    private Rigidbody2D rb;
    public Sprite[] Attack;
    public Sprite[] Dash;

    public Sprite idle;

    private bool swing = false;
    private bool dash = false;

    public SpriteRenderer spriteRenderer;

    public Move playerRef;

    public int health = 100;

    public int attackLen = 6;

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
        //ChangeSprite();
        if (swing)
        {
            AttackAnimation(attackLen -= 1);
        }
        else if (dash)
            DashAttack(attackLen -= 1);
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
        if (collision.collider.GetType() == typeof(CapsuleCollider2D))
        {
            Debug.Log("Coliided");
            if (collision.gameObject.tag == "Player")
            {

                swing = true;
                Swing();
            }
        }// capsule collider shit
        else if (collision.GetType() == typeof(BoxCollider2D))
        {
            if (collision.gameObject.tag == "Player")
            {

                dash = true;
                Swing();
            }
        }// box collider shit
    }

    private void AttackAnimation(int i)
    {
        if (i < 0)
        {
            dash = false;
            spriteRenderer.sprite = idle;
            attackLen = 6;
        }
        else
            spriteRenderer.sprite = Attack[i];
    }

    private void DashAttack(int i)
    {
        if (i < 0)
        {
            attackLen = 6;
            dash = false;
            spriteRenderer.sprite = idle;
        }
        else
            spriteRenderer.sprite = Dash[i];
    }

    private void Swing()
    {
        playerRef.Attacked();
    }


}
