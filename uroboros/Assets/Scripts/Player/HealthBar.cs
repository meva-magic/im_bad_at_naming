using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider healthBarDelay;

    [SerializeField] private float health;

    [SerializeField] private float lerpSpeed = 0.06f;

    private void Start()
    {
        health = PlayerHealth.instance.maxHealth;
    }

    private void Update()
    {
        health = PlayerHealth.instance.health;

        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if(healthSlider.value != healthBarDelay.value)
        {
            healthBarDelay.value = Mathf.Lerp(healthBarDelay.value, health, lerpSpeed);
        }
    }
}
