using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

static public class RayFromCamera
{
    static public RaycastHit2D CastRayFromMousePosAlongZAxis(LayerMask maskForSelectng, bool debuging)
    {
        Ray fromCameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hitInfo = Physics2D.Raycast(fromCameraRay.origin, fromCameraRay.direction, 150f);
        
        if (debuging) Debug.DrawRay(fromCameraRay.origin, fromCameraRay.direction * 150f, Color.yellow, .1f);
        return hitInfo;
    }
}
