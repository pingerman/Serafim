using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {

    static Slider healthSlider;
	
	void Awake () {
        healthSlider = transform.Find("Health Slider").GetComponent<Slider>();
        healthSlider.maxValue = Player.Instance.GetHealth();
        healthSlider.value = Player.Instance.GetHealth();
    }

    public static void GetDamage(float damage)
    {
        var playerHealth = Player.Instance.GetHealth();
        playerHealth -= damage;
        if (playerHealth <= 0f)
        {
            Debug.Log("Player Dead!");
            Application.LoadLevel(0);
        }
        else
        {
            healthSlider.value = playerHealth;
            Player.Instance.SetHealth(playerHealth);
        }
    }
}
