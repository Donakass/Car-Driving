using UnityEngine;
using UnityEngine.SceneManagement; // Необходимо для работы с загрузкой сцен

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private string sceneName; // Имя сцены, задаваемое через инспектор

    // Метод для запуска сцены
    public void OnPlayButtonPressed()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName); // Загрузка сцены с указанным именем
        }
        else
        {
            Debug.LogError("Имя сцены не задано! Укажите имя сцены в инспекторе.");
        }
    }
}
