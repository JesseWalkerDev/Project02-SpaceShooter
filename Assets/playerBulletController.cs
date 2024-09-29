using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Destructible"))
        {
            ParticleSystem particleSystem = GetComponent<ParticleSystem>();
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            particleSystem.Play();
            Destroy(gameObject, 1);
        }
    }
    
    public float lifeTime = 0;
    
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > 2)
            Destroy(gameObject);
    }
}
