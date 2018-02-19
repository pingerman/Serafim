﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManagement : MonoBehaviour
{
    private RaycastHit2D hitInfo;
    static private GameObject room;
    private RayFromCamera rayCaster;

    private void Start()
    {
        rayCaster = new RayFromCamera();    
    }

    private void Update()
    {
        hitInfo =  rayCaster.CastRayFromMousePosAlongZAxis(LayerMask.GetMask("Room"));

        if (hitInfo)
        {
            room = hitInfo.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OpenNeighborhoodRooms(room.transform);
                HideBlackPanel();   
            }
        }
    }

    public static void HideBlackPanel()
    {
        room.transform.Find("Black Panel").gameObject.SetActive(false);
    }

    private void OpenNeighborhoodRooms(Transform room)
    {
        foreach (Transform item in room)
        {
            item.gameObject.SetActive(true);
        }
    }
}
