using UnityEngine;

public class AimedCurveSpawn : MonoBehaviour
{
    [SerializeField] private int bulletsAmount = 13;
    [SerializeField] private float startAngle = 0f, endAngle = 360f, fireRate;

    private Vector2 bulletMoveDiredtion;

    private void Start()
    {
        InvokeRepeating("Fire", 0f, fireRate);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = CurveBulletPool.instance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<CurveBullet>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }
}
