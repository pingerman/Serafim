using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeStatusObjectNow : MonoBehaviour
{
    public void ChangeEnableStatus()
    {
        string shouldLoadScene = PlayerPrefs.GetString("SelectedLevelForLoad");
        GameState.Instance.SetState(State.Play);
        SceneManager.LoadScene(shouldLoadScene);
        gameObject.SetActive(false);
    }
}
