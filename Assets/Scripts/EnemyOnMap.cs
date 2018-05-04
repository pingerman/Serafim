using UnityEngine;

/// <summary>
/// Класс, определяющий вражескую единицу
/// </summary>
public class EnemyOnMap : MonoBehaviour, IMapObject
{
    public EnemyObject[] enemies;

    public void Process()
    {
        throw new System.NotImplementedException();
    }

    /*void OnMouseDown()
    {
        //TODO вызвать панель боя    
    }*/

    /// <summary>
    /// Сохраняем список врагов текущей единицы в синглтон-хранилище для битвы
    /// </summary>
    //public void EnemiesSet()
    //{
    //    Debug.Log("Enemies Set!");
    //    BattleManagement.Instance.EnemiesSet(enemies);
    //}

    ///// <summary>
    ///// Получаем трансформ объекта (реализация для интерфейса IMapObject)
    ///// </summary>
    ///// <returns>Трансформ объекта</returns>
    //public Transform GetTransform()
    //{
    //    return transform;
    //}
}
