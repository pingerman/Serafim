using UnityEngine;

/// <summary>
/// Класс, отвечающий за раскрытие комнат
/// </summary>
public class MapManager : Singleton<MapManager>
{
    /// <summary>
    /// Сюда передается комната, на которую мы кликнули, передается через рейкастинг из активной камеры в сцену
    /// </summary>

    void Update()
    {
        // Получаем информацию о попадании луча в комнату, поиск комнат ограничен слоем Room
        var hitInfo = fromScreenRayInfo();

        // Если указатель над комнатой
        if (hitInfo && Input.GetKeyDown(KeyCode.Mouse0) && BattleManagement.Instance.obj == null) 
        {
            Debug.Log("Hit!");
            IMapObject obj = hitInfo.transform as IMapObject;
            obj.Process();
        }
    }

    /// <summary>
    /// Метод, генерирующий луч с позиции мыши на экране в сцену, на этот луч реагируют объекты со слоем Room
    /// </summary>
    /// <returns>Инорфмация о попадании</returns>
    RaycastHit2D fromScreenRayInfo()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hitInfo = Physics2D.Raycast(cameraRay.origin, cameraRay.direction, 30f, LayerMask.GetMask("Room"));
        return hitInfo;
    }
}
