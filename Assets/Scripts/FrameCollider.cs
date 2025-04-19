using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FrameCollider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // UI-элемент для отображения текущего счета
    [SerializeField] private TextMeshProUGUI highScoreText; // UI-элемент для отображения рекорда
    [SerializeField] private Material greenMaterial; // Материал для положительных очков
    [SerializeField] private Material redMaterial; // Материал для отрицательных очков
    [SerializeField] private GameObject[] targetObjects; // Объекты, к которым применяется материал

    private int scoreValue; // Значение очков для этой рамки
    private static int playerScore = 0; // Текущий счет игрока
    private static int highScore = 0; // Рекорд игрока

    private void Start()
    {
        // Генерация случайного числа от -100 до +100
        scoreValue = Random.Range(-100, 101);

        // Установка цвета рамки в зависимости от значения очков
        if (scoreValue > 0)
        {
            SetMaterialToGreen();
        }
        else
        {
            SetMaterialToRed();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Обновление очков игрока
            playerScore += scoreValue;

            // Обновление рекорда, если текущий счет больше
            if (playerScore > highScore)
            {
                highScore = playerScore;
            }

            // Обновление текста очков и рекорда
            UpdateScoreText();

            // Удаление рамки после взаимодействия
            Destroy(gameObject);
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + playerScore;
        }

        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }

    private void SetMaterialToGreen()
    {
        foreach (var obj in targetObjects)
        {
            obj.GetComponent<Renderer>().material = greenMaterial;
        }
    }

    private void SetMaterialToRed()
    {
        foreach (var obj in targetObjects)
        {
            obj.GetComponent<Renderer>().material = redMaterial;
        }
    }
}
