using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    public float speed = 5f; // �������� �������� ������
    public float roadLength = 10f; // ����� ������ �������� ������
    public float timer = 60f; // ������ ��� �������� �������

    private Vector3 startPosition;

    void Start()
    {
        // ��������� ��������� ������� ������
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

        // ���� ������ ���� �� ����� ������ ��������, ���������� � �������
        if (transform.position.z <= startPosition.z - roadLength && timer != 0)
        {
            transform.position = startPosition;
        }
    }
}

