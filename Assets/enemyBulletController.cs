using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletController : MonoBehaviour
{
    float lifeTime = 0;
    
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > 50)
            Destroy(gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player Ship"))
        {
            ParticleSystem particleSystem = GetComponent<ParticleSystem>();
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            particleSystem.Play();
            Destroy(gameObject, 3);
        }
    }
}
