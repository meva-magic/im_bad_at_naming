using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float bulletLife = 1f;
    public float rotation = 0f;
    public float speed = 1f;
    [SerializeField] private float rotationSpeed = 50.0f;
    private Vector2 spawnPoint;
    private float timer = 0f;

    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        if(timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector2 Movement(float timer) 
    {
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x+spawnPoint.x, y+spawnPoint.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyBullet();
            PlayerHealth.instance.TakeDamage(15);
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}


