using UnityEngine;

/// <summary>
/// Класс, отвечающий за раскрытие комнат
/// </summary>
public class MapManager : Singleton<MapManager>
{
    /// <summary>
    /// Сюда передается комната, на которую мы кликнули, передается через рейкастинг из активной камеры в сцену
    /// </summary>
    public LayerMask mapObjectsMask;

    void Update()
    {
        var hitInfo = fromScreenRayInfo(mapObjectsMask);

        if (hitInfo && Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            IMapObject obj = hitInfo.transform.GetComponent<IMapObject>();

            if (obj != null) obj.Process();
        }
    }

    /// <summary>
    /// Метод, генерирующий луч с позиции мыши на экране в сцену, на этот луч реагируют объекты со слоем Room
    /// </summary>
    /// <returns>Инорфмация о попадании</returns>
    RaycastHit2D fromScreenRayInfo(LayerMask mask)
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hitInfo = Physics2D.Raycast(cameraRay.origin, cameraRay.direction, 30f, mask);
        return hitInfo;
    }
}
