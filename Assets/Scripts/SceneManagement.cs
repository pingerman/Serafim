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
            Debug.Log("Push");
            btnTag = hitInfo.transform.tag;

            if (btnTag == SceneNames.Start.ToString())                sceneForLoad = SceneNames.Start.ToString();
            else if (btnTag == SceneNames.SelectLevel.ToString())     sceneForLoad = SceneNames.SelectLevel.ToString();
            else if (btnTag == SceneNames.SelectCharacter.ToString()) sceneForLoad = SceneNames.SelectCharacter.ToString();
            else if (btnTag == SceneNames.Battle.ToString())          sceneForLoad = SceneNames.Battle.ToString();
            else if (btnTag == SceneNames.Level1.ToString())          sceneForLoad = SceneNames.Level1.ToString();
            else if (btnTag == SceneNames.Level2.ToString())          sceneForLoad = SceneNames.Level2.ToString();
            else if (btnTag == SceneNames.Level3.ToString())          sceneForLoad = SceneNames.Level3.ToString();

            try
            {
                SceneManager.LoadScene(sceneForLoad);
            }
            catch (System.Exception)
            {
                Debug.Log(string.Format("You are trying to load incorrect scene {0}", sceneForLoad));
            }
            
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