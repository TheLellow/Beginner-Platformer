using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public TMP_Text healthText;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateUI();

        if (currentHealth <= 0)
        {
            // Reset player (simple respawn)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + currentHealth;
    }
}
