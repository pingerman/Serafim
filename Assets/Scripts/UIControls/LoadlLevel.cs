using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс, загружающий сцены
/// </summary>
public class LoadlLevel : MonoBehaviour
{
    /// <summary>
    /// Имя сцены, которую планируется загрузить
    /// </summary>
    public string sceneName;

    /// <summary>
    /// Метод, загружающий сцену, указанную в переменной sceneName
    /// </summary>
    public void LoadLevelProcess()
    {
        // Информация о сцене, которую мы хотим загрузить, может понадобиться в случах когда перед загрузкой сцены мы хотим загрузить "подготовительную сцену" и от туда попасть в желаемую
        PlayerPrefs.SetString("SelectedLevelForLoad", sceneName);

        // Если мы взаимодействуем с этим классом из сцены с выбором уровня, сначала нас перекинет в сцену выбора персонажа
        if (SceneManager.GetActiveScene().name == "SelectLevel" )
        {
            SceneManager.LoadScene("SelectCharacter");
            return;
        }
        // В любом другом уровне перекинет в указанную в переменной sceneName сцену
        else SceneManager.LoadScene(sceneName);
    }
}
