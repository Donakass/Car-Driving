using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI-������������

public class AssignFrame : MonoBehaviour
{
    [SerializeField] private Material greenMaterial; // ������� ��������
    [SerializeField] private Material redMaterial;   // ������� ��������       // ������ �� ��������� �������
    private int scoreValue; // ����, ������� ���� �����

    void Start()
    {
        // ���������� ��������� �������� ����� �� -100 �� 100
        scoreValue = Random.Range(-100, 101);

        // ��������� �������� � ����������� �� �������� �����
        Renderer renderer = GetComponent<Renderer>();
        if (scoreValue >= 0)
        {
            renderer.material = greenMaterial; // ������������� ���� - ������� ��������
        }
        else
        {
            renderer.material = redMaterial; // ������������� ���� - ������� ��������
        }

        // ��������� ����� ��������� �����
    }

    public int GetScoreValue()
    {
        return scoreValue; // ���������� �������� �����
    }
}

