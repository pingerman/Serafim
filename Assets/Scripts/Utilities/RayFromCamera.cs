using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayFromCamera
{
    public RaycastHit2D CastRayFromMousePosAlongZAxis(LayerMask maskForSelectng)
    {
        Ray fromCameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hitInfo = Physics2D.Raycast(fromCameraRay.origin, fromCameraRay.direction, 50f, maskForSelectng);
        return hitInfo;
    }
}
