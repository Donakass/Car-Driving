using UnityEngine;

public class SpawnFrames : MonoBehaviour
{
    [SerializeField] private GameObject greenFramePrefab; // Префаб зеленой рамки
    [SerializeField] private GameObject redFramePrefab; // Префаб красной рамки
    [SerializeField] private Transform road; // Ссылка на дорогу
    [SerializeField] private float spawnInterval = 5f; // Интервал между спавнами рамок
    [SerializeField] private float roadWidth = 5f; // Ширина дороги
    [SerializeField] private float frameLifetime = 10f; // Время жизни рамки

    private float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnFrame();
            spawnTimer = 0f;
        }
    }

    private void SpawnFrame()
    {
        // Случайно выбираем рамку (зеленую или красную)
        GameObject framePrefab = Random.value > 0.5f ? greenFramePrefab : redFramePrefab;

        // Случайная позиция на дороге
        float randomX = Random.Range(-roadWidth / 2, roadWidth / 2);
        Vector3 spawnPosition = new Vector3(randomX, 1f, road.position.z + 20f); // Появление впереди дороги

        // Создаем рамку
        GameObject frame = Instantiate(framePrefab, spawnPosition, Quaternion.identity);

        // Уничтожаем рамку через frameLifetime секунд
        Destroy(frame, frameLifetime);
    }
}
