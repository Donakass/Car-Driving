using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ProgressBar : MonoBehaviour
{
    public RectTransform progressBarForeground; // Ссылка на передний план прогресс-бара
    public float fillDuration = 5f;             // Время, за которое прогресс-бар заполняется

    private float timer = 0f;                   // Таймер для отслеживания времени
    private bool isFilling = false;             // Флаг для контроля заполнения
    private bool isPaused = false;              // Флаг для контроля паузы

    void Start()
    {
        // Запускаем заполнение прогресс-бара при старте игры
        StartFilling();
    }

    void Update()
    {
        if (timer >= 35)
        {
            SceneManager.LoadScene(2);
        }
        if (isFilling && !isPaused && timer < fillDuration)
        {
            // Увеличиваем таймер
            timer += Time.deltaTime;

            // Рассчитываем прогресс (от 0 до 1)
            float progress = timer / fillDuration;

            // Изменяем масштаб по оси X
            progressBarForeground.localScale = new Vector3(progress, 1f, 1f);
        }
    }

    public void StartFilling()
    {
        // Сбрасываем таймер и запускаем заполнение
        timer = 0f;
        isFilling = true;
        isPaused = false;

        // Устанавливаем начальный масштаб
        progressBarForeground.localScale = new Vector3(0f, 1f, 1f);
    }

    public void PauseFilling()
    {
        // Приостанавливаем заполнение
        isPaused = true;
    }

    public void ResumeFilling()
    {
        // Возобновляем заполнение
        isPaused = false;
    }
}
