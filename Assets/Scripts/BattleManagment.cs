using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс, отвечающий за переход в битву
/// </summary>
public class BattleManagement : Singleton<BattleManagement>
{
    /// <summary>
    /// Сюда передается пиктограмма врага на карте уровня, на которую мы кликнули, передается через рейкастинг из активной камеры в сцену
    /// </summary>
    Enemie enemie;

    /// <summary>
    /// Здесь хранится список врагов, с которыми вы столкнетесь на сцене битвы
    /// </summary>
    Enemy[] enemies;
    RaycastHit2D hitInfo;

    void Update()
    {
        // Получаем информацию о попадании луча в комнату, поиск комнат ограничен слоем Room
        hitInfo = fromScreenRayInfo();

        // Если указатель над комнатой
        if (hitInfo)
        {
            // Извлекаем ссылку на активного врага
            enemie = hitInfo.transform.GetComponent<Enemie>();

            // Указатель над иконкой врага, ожидаем клик левой кнопкой мыши
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //вызываем EnemiesSet() через метод EnemiesSet() у enemie, чтобы передать в BattleManagment список врагов
                enemie.EnemiesSet();
                // Переходим на сцену битвы
                battleStart();
            }
        }
    }

    /// <summary>
    /// Сохраняем список врагов для предстоящей битвы
    /// </summary>
    /// <param name="enemyObjects">Список врагов от выбранного противника на карте</param>
    public void EnemiesSet(EnemyObject[] enemyObjects)
    {
        enemies = new Enemy[enemyObjects.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = new Enemy();
            enemies[i].icon = enemyObjects[i].icon;
            enemies[i].type = enemyObjects[i].type;
            enemies[i].level = enemyObjects[i].level;
            enemies[i].health = enemyObjects[i].health;
            enemies[i].defence = enemyObjects[i].defence;
            enemies[i].attack = enemyObjects[i].attack;
        }
    }

    /// <summary>
    /// Метод, возвращающий список врагов для битвы
    /// </summary>
    /// <returns>Список врагов для битвы</returns>
    public Enemy[] GetEnemies()
    {
        return enemies;
    }

    /// <summary>
    /// Переход в битву
    /// </summary>
    void battleStart()
    {
        SceneManager.LoadScene("Battle");
    }

    /// <summary>
    /// Метод, генерирующий луч с позиции мыши на экране в сцену, на этот луч реагируют объекты со слоем Enemy
    /// </summary>
    /// <returns>Инорфмация о попадании</returns>
    RaycastHit2D fromScreenRayInfo()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hitInfo = Physics2D.Raycast(cameraRay.origin, cameraRay.direction, 30f, LayerMask.GetMask("Enemy"));
        return hitInfo;
    }
}
