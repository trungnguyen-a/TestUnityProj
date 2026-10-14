using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private TextMeshProUGUI healthText;
    
    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        healthText.text = "Health: " + healthSlider.value + "/" + healthSlider.maxValue;
    }

    public void SetHealth(int currentHealth)
    {
        healthSlider.value = currentHealth;
        healthText.text = "Health: " + healthSlider.value + "/" + healthSlider.maxValue;
    }
}
