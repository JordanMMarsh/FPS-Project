using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
        UpdateHealthText();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        UpdateHealthText();
        if (health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = health.ToString();
    }
}
