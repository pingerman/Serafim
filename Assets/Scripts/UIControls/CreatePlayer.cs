using UnityEngine;

/// <summary>
/// Класс, создающий объект игрока с требуемыми данными, указанными в инспекторе 
/// </summary>
public class CreatePlayer : MonoBehaviour
{
    /// <summary>
    /// Требуемое умение создаваемого игрока
    /// </summary>
    [SerializeField] Skill skill;

    /// <summary>
    /// Требуемое количество жизней создаваемого игрока
    /// </summary>
    [SerializeField] float health;

    /// <summary>
    /// Требуемое количество защиты создаваемого игрока
    /// </summary>
    [SerializeField] float defence;

    /// <summary>
    /// Требуемое основное, активное оружие создаваемого игрока
    /// </summary>
    [SerializeField] MainWeapon mainWeapon;

    /// <summary>
    /// Требуемое дополнительное, активное оружие создаваемого игрока
    /// </summary>
    [SerializeField] AdditionalWeapon additionalWeapon;

    /// <summary>
    /// Создание персонажа с требуемыми данными путем обращения к синглтону
    /// </summary>
    public void CreateProcess()
    {
        Player.Instance.SetSkill(skill);
        Player.Instance.SetHealth(health);
        Player.Instance.SetDefence(defence);
        Player.Instance.SetMainWeapon(mainWeapon);
        Player.Instance.SetAdditionalWeapon(additionalWeapon);
    }
}
