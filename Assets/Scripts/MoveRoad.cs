using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    public float speed = 5f; // Скорость движения дороги
    public float roadLength = 10f; // Длина одного сегмента дороги
    public float timer = 60f; // Таймер для проверки времени

    private Vector3 startPosition;

    void Start()
    {
        // Сохраняем начальную позицию дороги
        startPosition = transform.position;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
            Debug.Log("Time is up");
        }
            transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Если дорога ушла на длину одного сегмента, сбрасываем её позицию
        if (transform.position.z <= startPosition.z - roadLength && timer != 0)
        {
            transform.position = startPosition;
        }
    }
}

