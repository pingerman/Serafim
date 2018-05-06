using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс, определяющий вражескую единицу
/// </summary>
public class EnemyOnMap : MonoBehaviour, IMapObject
{
    public EnemyTemplate[] enemies;

    /// <summary>
    /// Метод, выполняющий действие при нажатии на иконку врага на карте
    /// </summary>
    public void Process()
    {
        Debug.Log("Enemy Process");
        SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
        BattleManager.Instance.obj = this;
    }

    /// <summary>
    /// Возвращает список врагов компоненту BattleManager
    /// </summary>
    /// <returns>Список врагов</returns>
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
    /// Метод, устанавливающий отряд врагов из рандомного списка (список берется из LevelSettings)
    /// </summary>
    /// <param name="enemyTypes">Список типов врагов для рандомной выборки</param>
    public void SetRandomEnemy(EnemyTemplate[] enemyTypes)
    {
        var enemyNum = Mathf.CeilToInt(Random.Range(1, 3));
        enemies = new EnemyTemplate[enemyNum];
        for (int i = 0; i < enemies.Length; i++)
        {
            var randomIndex = Mathf.CeilToInt(Random.Range(0, enemyTypes.Length));
            enemies[i] = enemyTypes[randomIndex];
        }
    }
}
