using UnityEngine;

/// <summary>
/// Представление игрока, игрок создается в классе CreatePlayer
/// </summary>
public class Player : Singleton<Player>
{
    /// <summary>
    /// Умение игрока
    /// </summary>
    Skill skill;
    
    /// <summary>
    /// Количество жизней игрока
    /// </summary>
    float health;

    /// <summary>
    /// Количество защиты игрока
    /// </summary>
    float defence;

    /// <summary>
    /// Основное, активное оружие игрока
    /// </summary>
    MainWeapon mainWeapon;

    /// <summary>
    /// Дополнительное, активное оружие игрока
    /// </summary>
    AdditionalWeapon additionalWeapon;
    
    // Выводим информацию о себе(игроке) при появлении в сцене
    void Start()
    {
        Debug.Log("Player has been created: " +
            "skill: " + skill + "\n" +
            "health: " + health + "\n" +
            "defence: " + defence + "\n" +
            "mainWeapon: " + mainWeapon + "\n" +
            "additionalWeapon: " + additionalWeapon);
    }

    /// <summary>
    /// Установка требуемого количества жизней игрока
    /// </summary>
    /// <param name="value">Количество жизней</param>
    public void SetHealth(float value)
    {
        health = value;
    }

    /// <summary>
    /// Получение значения количества жизней игрока
    /// </summary>
    /// <returns>количество жизней</returns>
    public float GetHealth()
    {
        return health;
    }

    /// <summary>
    /// Установка требуемого количества защиты игрока
    /// </summary>
    /// <param name="value">Количество защиты</param>
    public void SetDefence(float value)
    {
        defence = value;
    }

    /// <summary>
    /// Установка требуемого навыка игрока
    /// </summary>
    /// <param name="value">Навык</param>
    public void SetSkill(Skill value)
    {
        skill = value;
    }

    /// <summary>
    /// Установка основного, активного оружия игрока
    /// </summary>
    /// <param name="weapon">Основное оружие</param>
    public void SetMainWeapon(MainWeapon weapon)
    {
        mainWeapon = weapon;
    }

    /// <summary>
    /// Установка дополнительного, активного оружия игрока
    /// </summary>
    /// <param name="weapon">Дополнительное оружие</param>
    public void SetAdditionalWeapon(AdditionalWeapon weapon)
    {
        additionalWeapon = weapon;
    }
}
