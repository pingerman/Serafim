using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private RaycastHit2D hitInfo;
    private string       sceneForLoad;
    private string       btnTag;

    private void Start()
    {
        LevelText.linkToMethod += LoadLevel;
    }

    private void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}


public enum SceneNames
{
    Start,
    Level1,
    Level2,
    Level3,
    SelectCharacter,
    SelectLevel,
    Battle
}