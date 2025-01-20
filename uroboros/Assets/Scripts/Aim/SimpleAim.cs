using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSpawner : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject bullet;

    private void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
