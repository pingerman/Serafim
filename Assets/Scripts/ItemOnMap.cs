using UnityEngine;

/// <summary>
/// Класс, определяющий предмет на карте
/// </summary>
public class ItemOnMap : MonoBehaviour, IMapObject
{
    public ItemTemplate item;

    /// <summary>
    /// Метод, выполняющий действие при нажатии на иконку предмета на карте
    /// </summary>
    public void Process()
    {
        Debug.Log("Item: " + item.type.ToString() + " Level: " + item.level + " Points: " + item.points);
        Destroy(gameObject);
    }

    /// <summary>
    /// Метод, устанавливающий предмет из рандомного списка (список берется из LevelSettings)
    /// </summary>
    /// <param name="items">Список предметов для рандомной выборки</param>
    public void SetRandomItem(ItemTemplate[] items)
    {
        var randomIndex = Mathf.CeilToInt(Random.Range(0, items.Length - 1));
        item = items[randomIndex];
    }

}
