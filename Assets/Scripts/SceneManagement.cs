using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private RaycastHit2D hitInfo;
    private string       sceneForLoad;
    private string       btnTag;

    void Update()
    {
        //hitInfo = RayFromCamera.CastRayFromMousePosAlongZAxis(LayerMask.GetMask("UI"));
        hitInfo = RayFromCamera.CastRayFromMousePosAlongZAxis(LayerMask.NameToLayer("UI"), true);

        if (hitInfo)
        {
           
            
        }
        else
        {
            Debug.Log("Not");
        }
    }
}


public enum SceneNames
{
    Start,
    SelectCharacter,
    SelectLevel,
    Battle,
    Level1,
    Level2,
    Level3
}