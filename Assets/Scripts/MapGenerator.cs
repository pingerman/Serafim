using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Класс, отвечающий за генерацию двумерной карты, состоящей из корридоров и комнат
/// </summary>
public class MapGenerator : MonoBehaviour {

    public Transform RoomsParent;
    public Transform HorizontalCorridorsParent;
    public Transform VerticalCorridorsParent;
    List<Vector2> roomsPositions = new List<Vector2>();
    List<Vector2> horizontalCorridorsPositions = new List<Vector2>();
    List<Vector2> verticalCorridorsPositions = new List<Vector2>();
    public int MapWidth;
    public int MapHeight;
    float roomStep = 2f;
    float horizontalCorridorStepX = 3.8f;
    float horizontalCorridorStepY = 1.22f;
    float verticalCorridorStepX = 3.82f;
    float verticalCorridorStepY = 1.25f;
    public int[] Levels;
    public int CurrentLevel;


    public GameObject RoomPrefab;
    public GameObject HorizontalCorridorPrefab;
    public GameObject VerticalCorridorPrefab;
    public GameObject EnemyPrefab;
    public GameObject ItemPrefab;

    void Start()
    {
        ElementsPositionsGenerate();
        MapGenerate();
    }

    /// <summary>
    /// Метод, генерирующий разметку карты (комнаты, горизонтальные и вертикальные корридоры)
    /// </summary>
    void ElementsPositionsGenerate()
    {
        for (int i = 0; i < (MapWidth * MapHeight); i++)
        {
            var roomPosition = GetElementPositionByIndex(i, MapWidth);
            roomsPositions.Add(new Vector2(roomPosition.x * roomStep, roomPosition.y * roomStep));
        }

        for (int j = 0; j < (MapWidth * (MapHeight - 1)); j++)
        {
            var verticalCorridorPosition = GetElementPositionByIndex(j, MapWidth);
            verticalCorridorsPositions.Add(new Vector2(verticalCorridorPosition.x * verticalCorridorStepX, verticalCorridorPosition.y * verticalCorridorStepY));
        }

        for (int k = 0; k < ((MapWidth - 1) * MapHeight); k++)
        {
            var horizontalCorridordPosition = GetElementPositionByIndex(k, MapWidth - 1);
            horizontalCorridorsPositions.Add(new Vector2(horizontalCorridordPosition.x * horizontalCorridorStepX, horizontalCorridordPosition.y * horizontalCorridorStepY));
        }
    }

    /// <summary>
    /// Генерация пути карты
    /// </summary>
    void MapGenerate()
    {
        List<int> level = new List<int>();
        if (Levels[CurrentLevel] >= roomsPositions.Count) Levels[CurrentLevel] = roomsPositions.Count - 1;
        for (int i = 0; i < Levels[CurrentLevel]; i++)
        {
            var index = Mathf.CeilToInt(Random.Range(1, roomsPositions.Count));
            while (level.Contains(index)) { index = Mathf.CeilToInt(Random.Range(1, roomsPositions.Count)); } 
            level.Add(index);
        }
        level.Sort();
        SetRooms(level);
    }

    /// <summary>
    /// Инстацирование комнат и корридоров
    /// </summary>
    /// <param name="rooms">список сгенеренных позиций для комнат</param>
    void SetRooms(List<int> rooms)
    {
        List<GameObject> roomList = new List<GameObject>();
        var room = Instantiate(RoomPrefab, RoomsParent);
        room.transform.localPosition = new Vector3(roomsPositions[0].x, roomsPositions[0].y, 0);
        room.SetActive(true);
        roomList.Add(room);
        for (int i = 0; i < rooms.Count; i++)
        {
            var state = Mathf.CeilToInt(Random.Range(1, 6));
            switch (state)
            {
                case 1:
                case 2:
                    room = Instantiate(RoomPrefab, RoomsParent);
                    room.transform.localPosition = new Vector3(roomsPositions[rooms[i]].x, roomsPositions[rooms[i]].y, 0);
                    room.SetActive(false);
                    roomList.Add(room);
                    break;
                case 3:
                case 4:
                    room = Instantiate(RoomPrefab, RoomsParent);
                    room.transform.localPosition = new Vector3(roomsPositions[rooms[i]].x, roomsPositions[rooms[i]].y, 0);
                    room.SetActive(false);
                    roomList.Add(room);
                    var enemy = Instantiate(EnemyPrefab, room.transform);
                    enemy.GetComponent<EnemyOnMap>().SetRandomEnemy(LevelSettings.Instance.enemies);

                    break;
                case 5:
                    room = Instantiate(RoomPrefab, RoomsParent);
                    room.transform.localPosition = new Vector3(roomsPositions[rooms[i]].x, roomsPositions[rooms[i]].y, 0);
                    room.SetActive(false);
                    roomList.Add(room);
                    var item = Instantiate(ItemPrefab, room.transform);
                    item.GetComponent<ItemOnMap>().SetRandomItem(LevelSettings.Instance.items);
                    break;
                default: break;
            }
            Debug.Log("Room №: " + i + " | Room x: " + GetElementPositionByIndex(rooms[i], MapWidth).x + " Room y: " + GetElementPositionByIndex(rooms[i], MapWidth).y);
            var corridors = new List<GameObject>();
            bool isCross = false;
            if (i == 0)
            {
                corridors = SetCorridors(GetElementPositionByIndex(0, MapWidth), GetElementPositionByIndex(rooms[i], MapWidth), out isCross);
                corridors.Add(roomList[i+1]);
                isCross = false;
                roomList[0].GetComponent<Room>().DependedMapObjects = corridors;
            }
            else
            {
                corridors = SetCorridors(GetElementPositionByIndex(rooms[i - 1], MapWidth), GetElementPositionByIndex(rooms[i], MapWidth), out isCross);
                corridors.Add(roomList[i + 1]);
                if (isCross)
                {
                    roomList[i].GetComponent<Room>().DependedMapObjects.AddRange(corridors);
                }
                else
                {
                    roomList[i].GetComponent<Room>().DependedMapObjects = corridors;
                }
            }
        }
    }

    /// <summary>
    /// Генерация корридоров между двумя комнатами
    /// </summary>
    /// <param name="room">Комната, с которой начинается корридор</param>
    /// <param name="target">Комната, к которой корридор ведет</param>
    /// <param name="isCross">Возвращается ли корридор по уже пройденному корридору вспять (есть ли перекресток)</param>
    /// <returns>Список геймобжей корридоров</returns>
    List<GameObject> SetCorridors(Vector2 room, Vector2 target, out bool isCross)
    {
        var corridors = new List<GameObject>();
        var point = room;
        isCross = false;
        while (point != target)
        {
            Debug.Log("Point: " + point);
            if (target.x == point.x)
            {
                corridors.AddRange(GetVerticalPath(point, target));
                point = target;
            }
            else
            {
                if (target.y == point.y)
                {
                    corridors.AddRange(GetHorizontalPath(point, target));
                    point = target;
                }
                else
                {
                    if (target.x > point.x)
                    {
                        corridors.AddRange(GetHorizontalPath(point, target));
                        point.x = target.x;
                    }
                    else
                    {
                        if (point.y == room.y) isCross = true;
                        corridors.AddRange(GetHorizontalPath(point, target, true));
                        point.x = target.x;
                    }
                }
            }
        }
        if (corridors.Count == 0)
            return null;
        else
            return corridors;
    }

    /// <summary>
    /// Метод, получающий горизонтальный корридор относительно координат массива
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns>Геймобжект горизонтального корридора</returns>
    GameObject GetHorizontalCorridor(int x, int y)
    {
        if (x <= 0) return null;
        var corridorX = x - 1;
        var horizontalIndex = 0;
        if (corridorX <= 0 && y == 0)
        {
            horizontalIndex = 0;
        }
        else
        {
            horizontalIndex = (y * (MapWidth - 1)) + (x - 1);
        }
        Debug.Log("Horizontal Index: " + horizontalIndex);
        var horizontalCorridor = Instantiate(HorizontalCorridorPrefab, HorizontalCorridorsParent);
        horizontalCorridor.transform.localPosition = new Vector3(horizontalCorridorsPositions[horizontalIndex].x, horizontalCorridorsPositions[horizontalIndex].y, 0);
        horizontalCorridor.SetActive(false);
        return horizontalCorridor;
    }

    /// <summary>
    /// Метод, получающий вертикальный корридор относительно координат массива
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns>Геймобжект вертикального корридора</returns>
    GameObject GetVerticalCorridor(int x, int y)
    {
        if (y <= 0) return null;
        var corridorY = y - 1;
        var verticalIndex = 0;
        if ((x % MapWidth) > (MapWidth - 1)) x -= 1;
        if (corridorY <= 0)
        {
            verticalIndex = x;
        }
        else
        {
            verticalIndex = (corridorY * MapWidth) + x;
        }
        Debug.Log("Vertical Index: " + verticalIndex);
        var verticalCorridor = Instantiate(VerticalCorridorPrefab, VerticalCorridorsParent);
        verticalCorridor.transform.localPosition = new Vector3(verticalCorridorsPositions[verticalIndex].x, verticalCorridorsPositions[verticalIndex].y, 0);
        verticalCorridor.SetActive(false);
        return verticalCorridor;
    }

    /// <summary>
    /// Метод возвращает список корридоров, проложенных по горизонтальному пути к следующей цели
    /// </summary>
    /// <param name="begin">Точка, с которой начинается путь</param>
    /// <param name="target">Точка, на которой путь заканчивается</param>
    /// <returns>Список корридоров</returns>
    List<GameObject> GetVerticalPath(Vector2 begin, Vector2 target)
    {
        var corridors = new List<GameObject>();
        var yBegin = (int)Mathf.Min(begin.y, target.y);
        var yTarget = (int)Mathf.Max(begin.y, target.y);
        Debug.Log("yBegin:" + yBegin + "| yTarget:" + yTarget);
        for (int y = (yBegin + 1); y <= yTarget; y++)
        {
            var verticalGo = GetVerticalCorridor((int)begin.x, y);
            if (verticalGo != null)
            {
                corridors.Add(verticalGo);
            }
        }
        Debug.Log("corridors: " + corridors.Count);
        return corridors;
    }

    /// <summary>
    /// Метод возвращает список корридоров, проложенных по горизонтальному пути к следующей цели
    /// </summary>
    /// <param name="begin">Точка, с которой начинается путь</param>
    /// <param name="target">Точка, на которой путь заканчивается</param>
    /// <param name="revert">Поворачивается ли путь вспять (нужно для фиксирования перекрестка)</param>
    /// <returns>Список корридоров</returns>
    List<GameObject> GetHorizontalPath(Vector2 begin, Vector2 target, bool revert = false)
    {
        var corridors = new List<GameObject>();
        var xBegin = (int)Mathf.Min(begin.x, target.x);
        var xTarget = (int)Mathf.Max(begin.x, target.x);
        Debug.Log("xBegin:" + xBegin + "| xTarget:" + xTarget + "| Revert: " + revert);
        if (!revert)
        {
            for (int x = (xBegin + 1); x <= xTarget; x++)
            {
                Debug.Log("x: " + x + " beginY: " + begin.y);
                var horizontalGo = GetHorizontalCorridor(x, (int)begin.y);
                if (horizontalGo != null)
                {
                    corridors.Add(horizontalGo);
                }
            }
        }
        else
        {
            for (int x = xTarget; x >= (xBegin + 1); x--)
            {
                Debug.Log("x: " + x + " beginY: " + begin.y);
                var horizontalGo = GetHorizontalCorridor(x, (int)begin.y);
                if (horizontalGo != null)
                {
                    corridors.Add(horizontalGo);
                }
            }
        }
        Debug.Log("corridors: " + corridors.Count);
        return corridors;
    }

    /// <summary>
    /// Метод, получающий позицию элемента в двумерном массиве по его индексу и с указанием ширины массива
    /// </summary>
    /// <param name="index">Индекс элемента</param>
    /// <param name="mapWidth">Ширина двумерного массива</param>
    /// <returns>Позиция элемента в двумерном массиве</returns>
    Vector2 GetElementPositionByIndex(int index, int mapWidth)
    {
        var x = index % mapWidth;
        var y = (index - x) / mapWidth;
        return new Vector2(x, y);
    }

}
