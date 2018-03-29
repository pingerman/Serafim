using UnityEngine;

/// <summary>
/// Класс, отвечающий за раскрытие комнат
/// </summary>
public class RoomManagement : Singleton<RoomManagement>
{
    /// <summary>
    /// Сюда передается комната, на которую мы кликнули, передается через рейкастинг из активной камеры в сцену
    /// </summary>
    GameObject room;
    RaycastHit2D hitInfo;

    void Update()
    {
        // Получаем информацию о попадании луча в комнату, поиск комнат ограничен слоем Room
        hitInfo = fromScreenRayInfo();

        // Если указатель над комнатой
        if (hitInfo) 
        {
            // Извлекаем ссылку на активную комнату
            room = hitInfo.transform.gameObject; 

            // Указатель над комнатой, ожидаем клик левой кнопкой мыши
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Открываем дочерние коридоры и комнаты
                openNeighborhoodRooms(room.transform);

                // Убираем серый фон с активной комнаты
                hideBlackPanel();
            }
        }
    }

    /// <summary>
    /// Метод, который выключает серый фон поверх комнаты
    /// </summary>
    public void hideBlackPanel()
    {
        room.transform.Find("Black Panel").gameObject.SetActive(false);
    }

    /// <summary>
    /// Комнаты представляют из себя систему дочерних по отношению к друг другу объектов, этот метод включает видимость всех дочерних элементов на активной комнате
    /// </summary>
    /// <param name="room"></param>
    void openNeighborhoodRooms(Transform room)
    {
        foreach (Transform item in room) item.gameObject.SetActive(true);
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
