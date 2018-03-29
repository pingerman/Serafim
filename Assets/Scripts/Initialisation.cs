using UnityEngine;

/// <summary>
/// Класс, инициализирующий игру требуемыми сущностями
/// </summary>
public class Initialisation : MonoBehaviour
{
    void Start()
    {
        //TODO: Стоит перенести сюда все сущности, которые перемещаются из уровня в уровень     
        RoomManagement.Initialise();
    }
}
