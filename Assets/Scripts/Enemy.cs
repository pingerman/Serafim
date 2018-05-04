using UnityEngine;

/// <summary>
/// Класс для хранения информации о врагах в момент битвы
/// </summary>
[System.Serializable]
public class Enemy {

    /// <summary>
    /// Иконка врага
    /// </summary>
    public Sprite icon;

    /// <summary>
    /// Тип врага
    /// </summary>
    public EnemyType type;

    /// <summary>
    /// Уровень врага
    /// </summary>
    public int level;

    /// <summary>
    /// Количество жизней врага
    /// </summary>
    public float health;

    /// <summary>
    /// Количество защиты врага
    /// </summary>
    public float defence;

    /// <summary>
    /// Атака врага
    /// </summary>
    public float attack;
}
