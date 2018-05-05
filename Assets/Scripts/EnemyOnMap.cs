using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс, определяющий вражескую единицу
/// </summary>
public class EnemyOnMap : MonoBehaviour, IMapObject
{
    public EnemyTemplate[] enemies;

    public void Process()
    {
        Debug.Log("Enemy Process");
        SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
        BattleManager.Instance.obj = this;
    }

    /// <summary>
    /// Возвращает список врагов компоненту BattleManager
    /// </summary>
    /// <returns></returns>

    public Enemy[] GetEnemies()
    {
        return ConvertTemplatesToEnemyArray(enemies);
    }

    /// <summary>
    /// Выстраивает на основании ScriptableObject врагов
    /// </summary>
    /// <returns>Массив врагов</returns>
    private Enemy[] ConvertTemplatesToEnemyArray(EnemyTemplate[] enemies)
    {
        Enemy[] enemyObjects = new Enemy[enemies.Length];

        for (int i = 0; i < enemies.Length; i++)
        {
            enemyObjects[i] = new Enemy();
            enemyObjects[i].icon = enemies[i].icon;
            enemyObjects[i].type = enemies[i].type;
            enemyObjects[i].level = enemies[i].level;
            enemyObjects[i].health = enemies[i].health;
            enemyObjects[i].defence = enemies[i].defence;
            enemyObjects[i].attack = enemies[i].attack;
        }

        return enemyObjects;
    }


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
