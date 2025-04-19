using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // ������ �� ������ ������
    [SerializeField] private float distance = 10f; // ���������� ������ �� ������
    [SerializeField] private float height = 5f; // ������ ������ ��� �������
    [SerializeField] private float smoothSpeed = 0.125f; // �������� ����������� �������� ������

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target ��� ������ �� ��������!");
            return;
        }

        // ��������� ������� ������ ������ ������
        Vector3 targetPosition = target.position - target.forward * distance + Vector3.up * height;

        // ������� ����������� ������ � �������� �������
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // ������ ������ ������� �� ������
        transform.LookAt(target);
    }
}

