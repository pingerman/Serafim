using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialisation : MonoBehaviour
{
    private void Awake()
    {
        Singleton<RoomManagement>.Initialise();
    }
}
