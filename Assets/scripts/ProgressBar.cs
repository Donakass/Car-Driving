using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public RectTransform progressBarForeground; // Ссылка на передний план прогресс-бара
    public float fillDuration = 5f;             // Время, за которое прогресс-бар заполняется
    public float maxWidth = 200f;               // Максимальная ширина прогресс-бара

    private float timer = 0f;                   // Таймер для отслеживания времени

    void Update()
    {
        if (timer < fillDuration)
        {
            // Увеличиваем таймер
            timer += Time.deltaTime;

            // Рассчитываем прогресс (от 0 до 1)
            float progress = timer / fillDuration;

            // Изменяем ширину прогресс-бара
            progressBarForeground.sizeDelta = new Vector2(progress * maxWidth, progressBarForeground.sizeDelta.y);
        }
    }
}
