using UnityEngine;

/// <summary>
/// Представление предмета, ассет предмета хранится заранее в скриптуемых объектах в папке Scriptable Objects/Enemies
/// </summary>
[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
public class ItemTemplate : ScriptableObject
{
    /// <summary>
    /// Иконка предмета
    /// </summary>
    public Sprite icon;

    /// <summary>
    /// Тип предмета
    /// </summary>
    public ItemType type;

    /// <summary>
    /// Уровень предмета
    /// </summary>
    public int level;

    /// <summary>
    /// Количество полезной нагрузки (значение пользы зависит от типа предмета)
    /// </summary>
    public float points;

    /// <summary>
    /// Описание предмета
    /// </summary>
    public string description;
}
