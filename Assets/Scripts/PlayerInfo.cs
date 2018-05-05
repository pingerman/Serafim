using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{

    static Slider healthSlider;

    void Awake()
    {
        Debug.Log("Player info");
        healthSlider = transform.Find("Health Slider").GetComponent<Slider>();
        healthSlider.maxValue = Player.Instance.GetMaxHealth();
        healthSlider.value = Player.Instance.GetHealth();
    }

    public static void GetDamage(float damage)
    {
        var playerHealth = Player.Instance.GetHealth();
        playerHealth -= damage;
        if (playerHealth <= 0f)
        {
            Debug.Log("Player Dead!");
            SceneManager.UnloadScene("Battle");
            BattleManager.Instance.EnemyWin();
        }
        else
        {
            healthSlider.value = playerHealth;
            Player.Instance.SetHealth(playerHealth);
        }
    }
}
