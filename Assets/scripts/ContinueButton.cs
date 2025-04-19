using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public GameObject pauseCanvas; // Ссылка на Canvas для паузы
    public GameObject gameCanvas;  // Ссылка на игровой Canvas

    public void OnContinueButtonClick()
    {
        // Убираем Canvas паузы
        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(false);
        }

        // Показываем игровой Canvas
        if (gameCanvas != null)
        {
            gameCanvas.SetActive(true);
        }

        // Возобновляем время
        Time.timeScale = 1f;
    }
}
