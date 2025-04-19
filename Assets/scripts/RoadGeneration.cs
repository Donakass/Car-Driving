using UnityEngine;

public class RoadGeneration : MonoBehaviour
{
    public GameObject roadSegmentPrefab; // Префаб сегмента дороги
    public GameObject frameSpritePrefab; // Префаб спрайта рамки
    public float carSpeed = 10f; // Скорость машины (в единицах в секунду)
    public float roadSegmentLength = 10f; // Длина одного сегмента дороги
    public int roadDurationInSeconds = 60; // Длительность поездки в секундах

    private void Start()
    {
        GenerateRoad();
    }

    private void GenerateRoad()
    {
        // Рассчитываем количество сегментов дороги
        int segmentCount = Mathf.CeilToInt((carSpeed * roadDurationInSeconds) / roadSegmentLength);

        Vector3 startPosition = new Vector3(0, 0, 0); // Начальная позиция первого сегмента

        for (int i = 0; i < segmentCount; i++)
        {
            // Позиция текущего сегмента относительно первого
            Vector3 segmentPosition = startPosition + new Vector3(0, 0, i * roadSegmentLength);

            // Создаем сегмент дороги
            GameObject roadSegment = Instantiate(roadSegmentPrefab, segmentPosition, Quaternion.identity);
            roadSegment.transform.parent = transform;

            // Генерируем два спрайта рамок в центре сегмента дороги
            Vector3 centerPosition = segmentPosition;
            Instantiate(frameSpritePrefab, centerPosition + new Vector3(-2, 0, 0), Quaternion.identity, roadSegment.transform);
            Instantiate(frameSpritePrefab, centerPosition + new Vector3(3.5f, 0, 0), Quaternion.identity, roadSegment.transform);
        }
    }
}