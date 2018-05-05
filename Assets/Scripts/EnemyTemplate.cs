using UnityEngine;

/// <summary>
/// Представление врага, ассет врага хранится заранее в скриптуемых объектах в папке Scriptable Objects/Enemies
/// </summary>
[System.Serializable]
[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies/Enemy")]
public class EnemyTemplate : ScriptableObject {

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
