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
	}

	void Update()
	{
		DoIMove();
	}

	void DoIMove()
	{
		Vector2 v = new Vector2();

		if (Input.GetKey(KeyCode.W))
			v.y = 0.1f;
		if (Input.GetKey(KeyCode.S))
			v.y = -0.1f;
	//	else
		//	v.y = 0;

		if (Input.GetKey(KeyCode.A))
			v.x = -0.1f;
		if (Input.GetKey(KeyCode.D))
			v.x = 0.1f;
		//else
		//	v.x = 0;
	

        //Vector3 v3 = value.

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
    }


}
