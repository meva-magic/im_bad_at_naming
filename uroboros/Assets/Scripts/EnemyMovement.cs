using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveRange;
    private bool moveRight;

    private void Start()
    {
        //moveSpeed = 2f;
        moveRight = true;
    }

    private void FixedUpdate()
    {
        if (transform.position.x > moveRange)
        {
            moveRight = false;
        }

        else if (transform.position.x < -moveRange)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.fixedDeltaTime, transform.position.y);
        }

        else
        {
            transform.position = new Vector2(transform.position.x + -moveSpeed * Time.fixedDeltaTime, transform.position.y);
        }
    }
}
