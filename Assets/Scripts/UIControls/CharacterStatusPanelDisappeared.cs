using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс, вызывающийся в конце анимации исчезнования модального окна с детальной информацией о персонаже
/// </summary>
public class CharacterStatusPanelDisappeared : MonoBehaviour
{
    /// <summary>
    /// Метод, вызывающийся в конце анимации исчезнования модального окна
    /// </summary>
    public void DisappearingProcess()
    {
        /*
         * После выбора уровня, прежде чем начать игру, нам нужно определиться с выбором персонажа, 
         * значит нужно запомнить уровень, который мы хотели загрузить, 
         * а затем использовать его после выбора персонажа
         */
        string shouldLoadScene = PlayerPrefs.GetString("SelectedLevelForLoad");

        // Меняем состояние игры
        GameState.Instance.SetState(State.Play);

        // Загружаем уровень, который мы выбрали ранее
        SceneManager.LoadScene(shouldLoadScene);
    }
}
