using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player player;

    private Stats stats;
    private Image healthBar;

    private float barWidth;
    private float barHeight;

    private void Start()
    {
        stats = player.Core.GetCoreComponent<Stats>(ref stats);

        healthBar = GameObject.Find("Health Bar").GetComponent<Image>();

        barWidth = healthBar.rectTransform.sizeDelta.x;
        barHeight = healthBar.rectTransform.sizeDelta.y;
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
            healthBar.rectTransform.sizeDelta = new Vector2(currentHealth, barHeight);
        }
    }
}
