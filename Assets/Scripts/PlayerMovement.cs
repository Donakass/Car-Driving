using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float screenWidth; // Ширина экрана
    private Vector3 startPosition; // Начальная позиция машины
    private float currentSpeed; // Текущая скорость машины
    private bool isTouching; // Флаг, указывающий, касается ли пользователь экрана

    // Settings
    [SerializeField] private float motorForce = 10f; // Базовая скорость движения вперед
    [SerializeField] private float maxSpeed = 25f; // Максимальная скорость при касании
    [SerializeField] private float speedChangeRate = 50f; // Скорость изменения скорости
    [SerializeField] private float movementWidth = 5f; // Ширина плоскости движения

    private void Start()
    {
        screenWidth = Screen.width;
        startPosition = transform.position;
        currentSpeed = motorForce; // Начальная скорость равна базовой скорости
    }

    private void FixedUpdate()
    {
        HandleSpeed();
        GetInputAndMoveCar();
    }

    private void HandleSpeed()
    {
        // Плавное изменение скорости в зависимости от состояния касания
        if (isTouching)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, speedChangeRate * Time.fixedDeltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, motorForce, speedChangeRate * Time.fixedDeltaTime);
        }
    }

    private void GetInputAndMoveCar()
    {
        if (Input.touchCount > 0)
        {
            isTouching = true; // Пользователь касается экрана
            Touch touch = Input.GetTouch(0);
            float normalizedTouchPosition = touch.position.x / screenWidth; // Нормализуем позицию касания (0 - левая сторона, 1 - правая)
            float targetXPosition = Mathf.Lerp(-movementWidth, movementWidth, normalizedTouchPosition); // Преобразуем в позицию на плоскости

            // Ограничиваем движение в пределах ширины
            targetXPosition = Mathf.Clamp(targetXPosition, -movementWidth, movementWidth);

            // Устанавливаем позицию машины
            transform.position = new Vector3(targetXPosition, transform.position.y, transform.position.z + currentSpeed * Time.fixedDeltaTime);
        }
        else
        {
            isTouching = false; // Пользователь отпустил экран
            // Двигаем машину вперед с текущей скоростью
            transform.position += Vector3.forward * currentSpeed * Time.fixedDeltaTime;
        }
    }
}
