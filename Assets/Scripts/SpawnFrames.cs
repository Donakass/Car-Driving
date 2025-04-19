using UnityEngine;

public class SpawnFrames : MonoBehaviour
{
    [SerializeField] private GameObject greenFramePrefab; // ������ ������� �����
    [SerializeField] private GameObject redFramePrefab; // ������ ������� �����
    [SerializeField] private Transform road; // ������ �� ������
    [SerializeField] private float spawnInterval = 5f; // �������� ����� �������� �����
    [SerializeField] private float roadWidth = 5f; // ������ ������
    [SerializeField] private float frameLifetime = 10f; // ����� ����� �����

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
        // �������� �������� ����� (������� ��� �������)
        GameObject framePrefab = Random.value > 0.5f ? greenFramePrefab : redFramePrefab;

        // ��������� ������� �� ������
        float randomX = Random.Range(-roadWidth / 2, roadWidth / 2);
        Vector3 spawnPosition = new Vector3(randomX, 1f, road.position.z + 20f); // ��������� ������� ������

        // ������� �����
        GameObject frame = Instantiate(framePrefab, spawnPosition, Quaternion.identity);

        // ���������� ����� ����� frameLifetime ������
        Destroy(frame, frameLifetime);
    }
}
