using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu"; // Имя сцены главного меню

    public void OnExitButtonClick()
    {
        // Загружаем сцену главного меню
        SceneManager.LoadScene(mainMenuSceneName);

        // Возобновляем время
        Time.timeScale = 1f;
    }
}
