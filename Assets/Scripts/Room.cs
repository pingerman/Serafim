using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour, IMapObject
{
    public List<GameObject> DependedMapObjects = new List<GameObject>();

    public void Process()
    {
        Debug.Log("Room Process");
        hideBlackPanel();
        openNeighborhoodRooms();
    }

    /// <summary>
    /// Метод, который выключает серый фон поверх комнаты
    /// </summary>
    public void hideBlackPanel()
    {
        transform.Find("Black Panel").gameObject.SetActive(false);
    }

    /// <summary>
    /// Комнаты представляют из себя систему дочерних по отношению к друг другу объектов, этот метод включает видимость всех дочерних элементов на активной комнате
    /// </summary>
    /// <param name="room"></param>
    void openNeighborhoodRooms()
    {
        //foreach (Transform item in transform) item.gameObject.SetActive(true);
        SetPathActive(DependedMapObjects);
    }

    /// <summary>
    /// Активация прилежащего к комнате корридора
    /// </summary>
    /// <param name="path">список геймобжей корридоров</param>
    void SetPathActive(List<GameObject> path)
    {
        path.ForEach((x) => { x.SetActive(true); });
    }
}
