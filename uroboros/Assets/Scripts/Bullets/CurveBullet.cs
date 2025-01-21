using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBullet : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float destroyTimer = 3f;
    public float rotationSpeed = 50.0f;

    private void OnEnable()
    {
        Invoke("Destroy", destroyTimer);
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy();
            PlayerHealth.instance.TakeDamage(10);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}