using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{

	//public TextMeshProUGUI countText;
	//public GameObject instruct;
	//public GameObject winTextObject;
	private Rigidbody2D rb;
	private SpriteRenderer [] img;
	private SpriteRenderer spriteRenderer;


	public int health = 100;
	public Animator animator;

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
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		DoIMove();

		animator.SetFloat("Speed", Mathf.Abs(movementX));
	}

	void DoIMove()
	{
		Vector2 v = new Vector2();

		if (Input.GetKey(KeyCode.W))
			v.y = 0.1f;
		if (Input.GetKey(KeyCode.S))
			v.y = -0.1f;

		if (Input.GetKey(KeyCode.A))
		{
			v.x = -0.1f;
			spriteRenderer.flipX = true; 
		}
		if (Input.GetKey(KeyCode.D))
		{
			v.x = 0.1f;
			spriteRenderer.flipX = false; 
		}

		movementX = v.x;
		movementY = v.y;
	}



	public void Attacked()
	{
		health -= 10;
		if (health <= 0)
			Debug.Log("Died");
	}
	void FixedUpdate()
	{
		Vector2 movement = new Vector2(movementX,movementY);
		
		//jump = false;
		//rb.AddForce(movement * speed);
		rb.MovePosition(rb.position + movement);
	}


    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Coliided");
        if (collision.gameObject.tag == "SpeedBoost")
        {
            speed *= 2;
            Destroy(collision.gameObject);
        }
		else if(collision.gameObject.tag == "HealthBoost")
		{
			health += 50;
			Destroy(collision.gameObject);
		}
    }


}
