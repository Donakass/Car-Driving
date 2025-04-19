using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // Ссылка на объект машины
    [SerializeField] private float distance = 10f; // Расстояние камеры от машины
    [SerializeField] private float height = 5f; // Высота камеры над машиной
    [SerializeField] private float smoothSpeed = 0.125f; // Скорость сглаживания движения камеры

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target для камеры не назначен!");
            return;
        }

        // Вычисляем позицию камеры позади машины
        Vector3 targetPosition = target.position - target.forward * distance + Vector3.up * height;

        // Плавное перемещение камеры к желаемой позиции
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Камера всегда смотрит на машину
        transform.LookAt(target);
    }
}

