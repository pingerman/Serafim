using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour, IMapObject
{
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
        foreach (Transform item in transform) item.gameObject.SetActive(true);
    }
}
