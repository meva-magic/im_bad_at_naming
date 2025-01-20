using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSpawn : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform target;

    [SerializeField] private float shootRate;
    [SerializeField] private float bulletMoveSpeed;

    private float shootTimer;

    private void Update()
    {
        shootTimer -= Time.deltaTime;

        if(shootTimer <= 0)
        {
            shootTimer = shootRate;
            AimBullet aimBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<AimBullet>();
            aimBullet.InitializeBullet(target, bulletMoveSpeed);
        }
    }
}
