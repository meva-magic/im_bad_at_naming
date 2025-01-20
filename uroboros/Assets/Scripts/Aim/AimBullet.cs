using UnityEngine;

public class AimBullet : MonoBehaviour
{
    private Transform target;
    private float moveSpeed;
    private float destroyTimer;

    [SerializeField] private float destroyDistance = 6f;
    [SerializeField] private float destroyAfter = 1.5f;

    private void Update()
    {
        Vector3 moveDirNormalized = (target.position - transform.position).normalized;
        transform.position += moveDirNormalized * moveSpeed * Time.deltaTime;

        if(Vector3.Distance(transform.position, target.position) < destroyDistance)
        {
            Destroy(gameObject);
        }

        destroyTimer += Time.deltaTime;
        if (destroyTimer >= destroyAfter)
        {
            Destroy(gameObject);
        }
    }

    public void InitializeBullet(Transform target, float moveSpeed)
    {
        this.target = target;
        this.moveSpeed = moveSpeed;

        destroyTimer = 0f;
    }
}
