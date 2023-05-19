using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Stats stats;
    private Image image;

    private float barWidth;
    private float barHeight;

    private void Start()
    {
        image = GetComponent<Image>();
        stats = GetComponentInParent<Stats>();

        barWidth = image.rectTransform.sizeDelta.x;
        barHeight = image.rectTransform.sizeDelta.y;
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (stats.currentHealth > 0)
        {
            float currentHealth = (stats.currentHealth * barWidth) / stats.maxHealth;
            image.rectTransform.sizeDelta = new Vector2(currentHealth, barHeight);
        }
    }
}
