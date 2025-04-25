using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speedZ = 10f; // Постоянная скорость движения

    public float roadMinX = -5f; // Левая граница дороги
    public float roadMaxX = 5f;  // Правая граница дороги

    private bool isTouching = false;
    private Vector3 targetPosition;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Touch.performed += OnTouchPerformed;
        inputActions.Player.Touch.canceled += OnTouchCanceled;
    }

    private void OnDisable()
    {
        inputActions.Player.Touch.performed -= OnTouchPerformed;
        inputActions.Player.Touch.canceled -= OnTouchCanceled;
        inputActions.Disable();
    }

    private void OnTouchPerformed(InputAction.CallbackContext context)
    {
        isTouching = true;
        Vector2 touchPosition = context.ReadValue<Vector2>();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, Camera.main.transform.position.y));
        targetPosition = new Vector3(worldPosition.x, transform.position.y, transform.position.z);
    }

    private void OnTouchCanceled(InputAction.CallbackContext context)
    {
        isTouching = false;
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Ограничиваем движение по оси X в пределах границ дороги
        float clampedX = Mathf.Clamp(targetPosition.x, roadMinX, roadMaxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Движение по оси Z с постоянной скоростью
        transform.Translate(Vector3.forward * speedZ * Time.deltaTime);
    }
}
