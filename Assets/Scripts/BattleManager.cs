using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс, отвечающий за переход в битву
/// </summary>
public class BattleManager : Singleton<BattleManager>
{
    /// <summary>
    /// Сюда передается пиктограмма врага на карте уровня, на которую мы кликнули, передается через рейкастинг из активной камеры в сцену
    /// </summary>
    [HideInInspector]
    public EnemyOnMap obj;

    /// <summary>
    /// Здесь хранится список врагов, с которыми вы столкнетесь на сцене битвы
    /// </summary>
    Enemy[] enemies;
    RaycastHit2D hitInfo;

    void Start()
    {
        enemies = obj.GetEnemies();
    }

    public void EnemyLose()
    {
        Destroy(obj.gameObject);
        obj = null;
    }

    public void EnemyWin()
    {
        obj = null;
    }

    /// <summary>
    /// Метод, возвращающий список врагов для битвы
    /// </summary>
    /// <returns>Список врагов для битвы</returns>
    public Enemy[] GetEnemies()
    {
        return enemies;
    }
}
