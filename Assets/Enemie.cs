using UnityEngine;

/// <summary>
/// Класс, определяющий вражескую единицу
/// </summary>
public class Enemie : MonoBehaviour
{
    public EnemyObject[] enemies;

    /*void OnMouseDown()
    {
        //TODO вызвать панель боя    
    }*/

    /// <summary>
    /// Сохраняем список врагов текущей единицы в синглтон-хранилище для битвы
    /// </summary>
    public void EnemiesSet()
    {
        Debug.Log("Enemies Set!");
        BattleManagement.Instance.EnemiesSet(enemies);
    }
}
