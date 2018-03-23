using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManagement : MonoBehaviour
{
    static private GameObject room;
    private RaycastHit2D hitInfo;

    private void Update()
    {

        hitInfo = fromScreenRayInfo();

        if (hitInfo)
        {
            room = hitInfo.transform.gameObject;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                openNeighborhoodRooms(room.transform);
                hideBlackPanel();
            }
        }
    }

    public static void hideBlackPanel()
    {
        room.transform.Find("Black Panel").gameObject.SetActive(false);
    }

    private void openNeighborhoodRooms(Transform room)
    {
        foreach (Transform item in room) item.gameObject.SetActive(true);
    }

    private RaycastHit2D fromScreenRayInfo()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hitInfo = Physics2D.Raycast(cameraRay.origin, cameraRay.direction, 30f, LayerMask.GetMask("Room"));
        return hitInfo;
    }
}
