using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadlLevel : MonoBehaviour
{
    public string sceneName;

    public void LoadLevelProcess()
    {
        if (SceneManager.GetActiveScene().name == "SelectLevel" )
        {
            SceneManager.LoadScene("SelectCharacter");
            return;
        }
        else
        {
            PlayerPrefs.SetString("SelectedLevelForLoad", sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }
}
