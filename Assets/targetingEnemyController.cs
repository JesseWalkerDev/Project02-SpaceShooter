using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetingEnemyShip : MonoBehaviour
{
    float coolDown = 0;
    
    public int health = 3;
	public GameObject bulletPrefab;
	public float shootSpeed = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        GameObject player = GameObject.Find("Player");
        if (!player)
            return;
        float distanceToPlayer = transform.position.x - player.transform.position.x;
		if (coolDown <= 0 && distanceToPlayer < 20)
		{
			GameObject bullet = Instantiate(bulletPrefab);
			bullet.transform.position = transform.position - new Vector3(0.25f, 0f, 0f);;
            Vector2 bulletVelocity = (player.transform.position - transform.position).normalized * 4;
			bullet.GetComponent<Rigidbody2D>().velocity = bulletVelocity;
			
			coolDown = shootSpeed;
		}
    }
    
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player Bullet"))
        {
            health --;
            if (health <= 0)
            {
                scoreDisplay.score += 100;
                Destroy(gameObject);
            }
        }
    }
}
