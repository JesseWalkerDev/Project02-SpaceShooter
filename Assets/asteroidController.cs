using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour
{
    static int spriteCount = 5;
    
    public Sprite[] sprites = new Sprite[spriteCount];
    
    public int health = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, spriteCount - 1)];
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player Bullet"))
        {
            health --;
            if (health <= 0)
            {
                ParticleSystem particleSystem = GetComponent<ParticleSystem>();
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                particleSystem.Play();
                scoreDisplay.score += 10;
                Destroy(gameObject, 3);
            }
        }
    }
}
