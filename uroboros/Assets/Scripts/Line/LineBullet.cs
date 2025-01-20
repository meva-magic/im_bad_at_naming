using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float bulletLife = 1f;
    public float rotation = 0f;
    public float speed = 1f;
    public Vector2 spawnPoint;
    private float timer = 0f;

    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
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
}


