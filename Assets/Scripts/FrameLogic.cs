using UnityEngine;

public class FrameLogic : MonoBehaviour
{
    [SerializeField] private int minScoreValue = -100; // ����������� �������� �����
    [SerializeField] private int maxScoreValue = 100;  // ������������ �������� �����
    private int scoreValue; // �������� ����� (��������������� ��������)

    private void Start()
    {
        // ������������� ��������� �������� �����
        scoreValue = Random.Range(minScoreValue, maxScoreValue + 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���������, ��� ������������ ��������� � �������
        {
            // ��������� ���� ������
            PlayerScore.Instance.UpdateScore(scoreValue);

            // ���������� �����
            Destroy(gameObject);
        }
    }
}

