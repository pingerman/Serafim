using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Панель с данными врага в режиме битвы, нажимая на которую игрок наносит врагу урон
/// </summary>
public class EnemyPanel : MonoBehaviour {

    public Animator enemyAnim;
    Enemy enemy;
    Image enemyIcon;
    Slider healthSlider;

    /// <summary>
    /// Инициализация панели врага (вместо Start, т.к. инициализация происходит в ходе выполнения кода в Awake() в EnemyPanelInitialisation)
    /// </summary>
    public void Initialise()
    {
        enemyAnim.gameObject.SetActive(true);
        enemyIcon = transform.Find("Enemie Icon").GetComponent<Image>();
        healthSlider = transform.Find("Health Slider").GetComponent<Slider>();
    }

    /// <summary>
    /// Метод, наносящий урон врагу от игрока
    /// </summary>
    public void EnemyHit()
    {
        enemy.health -= 1;
        if (enemy.health <= 0)
        {
            enemyAnim.SetTrigger("Death");
            gameObject.SetActive(false);
            GameObject.Find("Initialisation").GetComponent<EnemyPanelInitialisation>().EnemyCheck();
        }
        else
        {
            enemyAnim.SetTrigger("Hit");
            healthSlider.value = enemy.health;
            PlayerInfo.GetDamage(enemy.attack);
        }
    }

    /// <summary>
    /// Передача данных о враге, закрепленным в группе за данной панелью. Вызывается из EnemyPanelInitialisation
    /// </summary>
    /// <param name="pEnemy"></param>
    public void SetEnemy(Enemy pEnemy)
    {
        enemy = pEnemy;
        enemyIcon.sprite = enemy.icon;
        //TODO: нужно решить как передавать в enemyAnim пикчи врагов, в виде спрайтов или же какого-то геймобжа с анимациями
        enemyAnim.GetComponent<Image>().sprite = enemy.icon;
        healthSlider.maxValue = enemy.health;
    }
}
