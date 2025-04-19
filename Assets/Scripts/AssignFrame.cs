using UnityEngine;

public class AssignFrame : MonoBehaviour
{
    [SerializeField] private Material greenMaterial; // Зелёный материал
    [SerializeField] private Material redMaterial;   // Красный материал
    [SerializeField] private GameObject[] targetObjects; // Массив объектов, к которым будет применяться материал
    private int scoreValue; // Очки, которые даёт рамка

    void Start()
    {
        // Генерируем случайное значение очков от -100 до 100
        scoreValue = Random.Range(-100, 101);

        // Назначаем материал в зависимости от значения очков
        foreach (GameObject target in targetObjects)
        {
            if (target != null) // Проверяем, что объект не null
            {
                Renderer renderer = target.GetComponent<Renderer>();
                if (renderer != null) // Проверяем, что у объекта есть Renderer
                {
                    if (scoreValue >= 0)
                    {
                        renderer.material = greenMaterial; // Положительные очки - зелёный материал
                    }
                    else
                    {
                        renderer.material = redMaterial; // Отрицательные очки - красный материал
                    }
                }
            }
        }
    }

    public int GetScoreValue()
    {
        return scoreValue; // Возвращаем значение очков
    }
}
