using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseCanvas; // Ссылка на Canvas для паузы
    public GameObject gameCanvas;  // Ссылка на игровой Canvas

    private bool isPaused = false; // Флаг для контроля состояния паузы

    public void OnPauseButtonClick()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        // Останавливаем время
        Time.timeScale = 0f;

        // Включаем Canvas паузы
        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(true);
        }

        // Скрываем игровой Canvas
        if (gameCanvas != null)
        {
            gameCanvas.SetActive(false);
        }

        isPaused = true;
    }

    private void ResumeGame()
    {
        // Возобновляем время
        Time.timeScale = 1f;

        // Отключаем Canvas паузы
        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(false);
        }

        // Показываем игровой Canvas
        if (gameCanvas != null)
        {
            gameCanvas.SetActive(true);
        }

        isPaused = false;
    }
}
