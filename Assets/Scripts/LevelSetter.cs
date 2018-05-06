using UnityEngine;

/// <summary>
/// Класс, устанавливающий настройки уровня, на который будет осуществлен переход (должен вызываться там же где и LoadLevel)
/// </summary>
public class LevelSetter : MonoBehaviour {

    public EnemyTemplate[] enemies;

    public ItemTemplate[] items;

    /// <summary>
    /// Метод, передающий список врагов и предметов, которыми будет располагать уровень
    /// </summary>
    public void SetLevel()
    {
        LevelSettings.Instance.enemies = enemies;
        LevelSettings.Instance.items = items;
    }
}
