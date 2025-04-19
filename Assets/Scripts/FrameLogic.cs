using UnityEngine;

public class FrameLogic : MonoBehaviour
{
    [SerializeField] private int minScoreValue = -100; // Минимальное значение очков
    [SerializeField] private int maxScoreValue = 100;  // Максимальное значение очков
    private int scoreValue; // Значение очков (устанавливается случайно)

    private void Start()
    {
        // Устанавливаем случайное значение очков
        scoreValue = Random.Range(minScoreValue, maxScoreValue + 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, что столкновение произошло с игроком
        {
            // Обновляем очки игрока
            PlayerScore.Instance.UpdateScore(scoreValue);

            // Уничтожаем рамку
            Destroy(gameObject);
        }
    }
}

