using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.PlasticSCM.Editor.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
	public SpriteRenderer thrust;
	public SpriteRenderer strongThrust;
	public SpriteRenderer upThrust;
	public SpriteRenderer downThrust;
	
	public float speed = 5f;
	public static int health = 3;
	public GameObject bulletPrefab;
	
	public float shootSpeed = 5;
	
	float coolDown = 0;
	Rigidbody2D body;
	
	//Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
	
	// Start is called before the first frame update
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 inputDirection;
		inputDirection.x = Input.GetAxisRaw("Horizontal");
		inputDirection.y = Input.GetAxisRaw("Vertical");
		inputDirection.Normalize();
		
		body.velocity = inputDirection * speed;
		
		thrust.enabled = inputDirection.x >= 0;
		strongThrust.enabled = inputDirection.x > 0;
		upThrust.enabled = inputDirection.y > 0;
		downThrust.enabled = inputDirection.y < 0;
		
		coolDown -= Time.deltaTime;
		if (coolDown <= 0 && Input.GetKey(KeyCode.Space))
		{
			GameObject bullet = Instantiate(bulletPrefab);
			bullet.transform.position = transform.position + new Vector3(0.5f, 0f, 0f);
			bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 8;
			coolDown = shootSpeed;
		}
		
		if (transform.position.y > 6f)
			transform.position = new Vector3(transform.position.x, -6f, transform.position.z);
		else if (transform.position.y < -6f)
			transform.position = new Vector3(transform.position.x, 6f, transform.position.z);
	}
	
	void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Hazard"))
        {
            health --;
            if (health <= 0)
			{
				GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject, 1);
			}
        }
    }
	
	void OnDisable()
	{
		health = 3;
		scoreDisplay.score = 0;
		SceneManager.LoadScene("End", LoadSceneMode.Single);
	}
}
