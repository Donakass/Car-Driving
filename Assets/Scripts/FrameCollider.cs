using TMPro;
using UnityEngine;

public class FrameCollider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // UI-элемент для отображения текущего счета
    [SerializeField] private Material greenMaterial; // Материал для положительных очков
    [SerializeField] private Material redMaterial; // Материал для отрицательных очков
    [SerializeField] private GameObject[] targetObjects; // Объекты, к которым применяется материал
    [SerializeField] private TextMeshPro frameText; // Текст на рамке для отображения значения очков

    private int scoreValue; // Значение очков для этой рамки
    private static int playerScore = 0; // Текущий счет игрока

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

        // Установка текста на рамке
        UpdateFrameText();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Обновление очков игрока
            playerScore += scoreValue;

            // Обновление текста очков
            UpdateScoreText();

            // Удаление рамки после взаимодействия
            Destroy(gameObject);
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "" + playerScore;
        }
    }

    private void UpdateFrameText()
    {
        if (frameText != null)
        {
            // Установка текста с учетом знака
            frameText.text = (scoreValue > 0 ? "+" : "") + scoreValue;
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
