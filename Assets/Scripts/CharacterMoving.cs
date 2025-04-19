using UnityEngine;

public class CharacterMobing : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения
    private Vector2 startTouchPosition; // Начальная позиция касания
    private Vector2 endTouchPosition;   // Конечная позиция касания
    private float swipeThreshold = 50f; // Минимальная длина свайпа для регистрации

    void Update()
    {
        HandleSwipe();
    }

    private void HandleSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Сохраняем начальную позицию касания
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    // Сохраняем конечную позицию касания
                    endTouchPosition = touch.position;

                    // Вычисляем разницу между начальной и конечной позицией
                    Vector2 swipeDelta = endTouchPosition - startTouchPosition;

                    // Проверяем, является ли свайп горизонтальным
                    if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y) && Mathf.Abs(swipeDelta.x) > swipeThreshold)
                    {
                        if (swipeDelta.x > 0)
                        {
                            MoveRight();
                        }
                        else
                        {
                            MoveLeft();
                        }
                    }
                    break;
            }
        }
    }

    private void MoveLeft()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void MoveRight()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
