using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManagement : MonoBehaviour
{
    RaycastHit2D hitInfo;
    static GameObject room;

    private void Update()
    {
        Ray fromCameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        hitInfo = Physics2D.Raycast(fromCameraRay.origin, fromCameraRay.direction, 50f, LayerMask.GetMask("Room"));

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
