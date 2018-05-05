using UnityEngine;

/// <summary>
/// Класс, при запуске, инициализирующий игру требуемыми сущностями
/// </summary>
public class Initialisation : MonoBehaviour
{
    [SerializeField] LayerMask mapObjectsMask;

    void Start()
    { 
        MapManager.Instance.mapObjectsMask = mapObjectsMask;
    }
}
