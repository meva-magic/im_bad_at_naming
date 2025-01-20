using UnityEngine;

public class AimBullets : MonoBehaviour
{
    public float moveSpeed;
    private Transform player;
    private Vector2 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }
    
    private void FixedUpdate() 
    {
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.fixedDeltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
