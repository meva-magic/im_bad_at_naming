using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject onHitVFX;
    [SerializeField] private bool isEnemyProjectile = false;
    [SerializeField] private float projectileRange = 10f;

    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        MoveProjectile();
        CheckProjectileRange();
    }

    public bool GetIsEnemyProjectile()
    {
        return isEnemyProjectile;
    }

    public void UpdateProjectileRange(float projectileRange)
    {
        this.projectileRange = Mathf.Max(projectileRange, 0f);
    }

    public void UpdateMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = Mathf.Max(moveSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger) return;

        //if (other.TryGetComponent(out EnemyHealth enemyHealth) || other.TryGetComponent(out PlayerController player))
        if (other.TryGetComponent(out PlayerController player) || player && isEnemyProjectile)
        {
            //if ((player && isEnemyProjectile) || (enemyHealth && !isEnemyProjectile))
            {
                //player?.TakeDamage(1, transform);
                Instantiate(onHitVFX, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    private void CheckProjectileRange()
    {
        if (Vector2.Distance(transform.position, startPosition) > projectileRange)
        {
            Destroy(gameObject);
        }
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }
}
