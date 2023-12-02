using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

	private Rigidbody2D rb;
	private SpriteRenderer[] img;
	private SpriteRenderer spriteRenderer;

	public Animator animator;

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;

	private float movementX;
	private float movementY;
	public float speed;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
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

	public void TakeDamage()
	{
		currentHealth -= 10;

		healthBar.SetHealth(currentHealth);

		animator.SetTrigger("Hurt");

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Debug.Log("You died!");

		animator.SetBool("isDead", true);

		FindObjectOfType<Boss1>().PlayerDied();

		GetComponent<Collider2D>().enabled = false;
		this.enabled = false;
	}

	void FixedUpdate()
	{
		Vector2 movement = new Vector2(movementX, movementY);

		rb.MovePosition(rb.position + movement);
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collided");
		if (collision.gameObject.tag == "SpeedBoost")
		{
			speed *= 4;
			Destroy(collision.gameObject);
		}
		else if (collision.gameObject.tag == "HealthBoost")
		{
			currentHealth += 50;
			Destroy(collision.gameObject);
		}
	}


}