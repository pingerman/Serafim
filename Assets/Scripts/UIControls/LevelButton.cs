using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelButton : Button
{
    private string btnTag;
    private string sceneForLoad;

    public override void OnPointerClick(PointerEventData eventData)
    {
        btnTag = gameObject.tag;

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
}
