using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float targetXPosition; // Целевая позиция по оси X
    private float screenWidth; // Ширина экрана
    private Vector3 startPosition; // Начальная позиция машины

    // Settings
    [SerializeField] private float motorForce;
    [SerializeField] private float moveSpeed = 10f; // Скорость движения влево/вправо
    [SerializeField] private float movementWidth = 5f; // Ширина плоскости движения

    private void Start()
    {
        screenWidth = Screen.width;
        startPosition = transform.position;
        targetXPosition = startPosition.x;
    }

    private void FixedUpdate()
    {
        GetInput();
        MoveCar();
    }

    private void GetInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float normalizedTouchPosition = touch.position.x / screenWidth; // Нормализуем позицию касания (0 - левая сторона, 1 - правая)
            targetXPosition = Mathf.Lerp(-movementWidth, movementWidth, normalizedTouchPosition); // Преобразуем в позицию на плоскости
        }
    }

    private void MoveCar()
    {
        // Ограничиваем движение в пределах ширины
        targetXPosition = Mathf.Clamp(targetXPosition, -movementWidth, movementWidth);

        // Двигаем машину к целевой позиции
        Vector3 targetPosition = new Vector3(targetXPosition, transform.position.y, transform.position.z + motorForce * Time.fixedDeltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
    }
}
