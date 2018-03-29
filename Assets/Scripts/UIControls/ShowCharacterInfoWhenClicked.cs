using UnityEngine;

/// <summary>
/// Класс, отвечающий за генерацию модального окна с детальной информацией о персонаже
/// </summary>
public class ShowCharacterInfoWhenClicked : MonoBehaviour
{
    /// <summary>
    /// модальные окна с информацией о персонаже являются выключенными игровыми объектами, существующими в сцене, указываются в эту переменную
    /// </summary>
    [SerializeField] GameObject characterInfoPanel;

    /// <summary>
    /// Метод, включающий объект панели детальной информации о персонажей в сцене, вызывается по нажатию UI кнопки
    /// </summary>
    public void OpenCharacterInfo()
    {
        if (GameState.Instance.GetState() == State.Modal) return;
        characterInfoPanel.SetActive(true);
        GameState.Instance.SetState(State.Modal);
    }
}
