using UnityEngine;
using UnityEngine.UI; // Для работы с UI-компонентами

public class AssignFrame : MonoBehaviour
{
    [SerializeField] private Material greenMaterial; // Зеленый материал
    [SerializeField] private Material redMaterial;   // Красный материал       // Ссылка на текстовый элемент
    private int scoreValue; // Очки, которые дает рамка

    void Start()
    {
        // Генерируем случайное значение очков от -100 до 100
        scoreValue = Random.Range(-100, 101);

        // Назначаем материал в зависимости от значения очков
        Renderer renderer = GetComponent<Renderer>();
        if (scoreValue >= 0)
        {
            renderer.material = greenMaterial; // Положительные очки - зеленый материал
        }
        else
        {
            renderer.material = redMaterial; // Отрицательные очки - красный материал
        }

        // Обновляем текст значением очков
    }

    public int GetScoreValue()
    {
        return scoreValue; // Возвращаем значение очков
    }
}

