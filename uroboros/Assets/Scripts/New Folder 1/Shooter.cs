using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletMoveSpeed = 10f;
    [SerializeField] private int burstCount = 1;
    [SerializeField] private int projectilesPerBurst = 1;
    [SerializeField] [Range(0f, 360f)] private float angleSpread = 15f;
    [SerializeField] private float startDistance = 0.1f;
    [SerializeField] private float timeBetweenBursts = 0.5f;
    [SerializeField] private float restTime = 1f;
    [SerializeField] private bool stagger;
    [SerializeField] private bool oscillate;

    private bool isShooting = false;
    private float angleStep;

    private void OnValidate()
    {
        projectilesPerBurst = Mathf.Max(projectilesPerBurst, 1);
        burstCount = Mathf.Max(burstCount, 1);
        timeBetweenBursts = Mathf.Max(timeBetweenBursts, 0.1f);
        restTime = Mathf.Max(restTime, 0.1f);
        startDistance = Mathf.Max(startDistance, 0.1f);
        angleSpread = Mathf.Clamp(angleSpread, 0f, 360f);
        bulletMoveSpeed = Mathf.Max(bulletMoveSpeed, 0.1f);

        if (angleSpread == 0f)
        {
            projectilesPerBurst = 1;
        }

        angleStep = angleSpread / (projectilesPerBurst - 1);
    }

    public void Attack()
    {
        if (!isShooting)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    private IEnumerator ShootRoutine()
    {
        isShooting = true;

        float startAngle = transform.eulerAngles.z;
        float currentAngle = startAngle;
        float endAngle = startAngle + angleSpread;

        float timeBetweenProjectiles = stagger ? timeBetweenBursts / projectilesPerBurst : 0f;

        for (int i = 0; i < burstCount; i++)
        {
            if (!oscillate)
            {
                currentAngle = startAngle;
            }
            else if (i % 2 != 0)
            {
                currentAngle = endAngle;
                endAngle = startAngle;
                startAngle = currentAngle;
                angleStep *= -1;
            }

            for (int j = 0; j < projectilesPerBurst; j++)
            {
                Vector2 pos = FindBulletSpawnPos(currentAngle);

                GameObject newBullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
                newBullet.transform.right = (newBullet.transform.position - transform.position).normalized;

                if (newBullet.TryGetComponent(out Projectile projectile))
                {
                    projectile.UpdateMoveSpeed(bulletMoveSpeed);
                }

                currentAngle += angleStep;

                if (stagger)
                {
                    yield return new WaitForSeconds(timeBetweenProjectiles);
                }
            }

            yield return new WaitForSeconds(timeBetweenBursts);
        }

        isShooting = false;
    }

    private Vector2 FindBulletSpawnPos(float angle)
{
    Vector2 pos = transform.position;
    pos += new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * startDistance;
    return pos;
}
}