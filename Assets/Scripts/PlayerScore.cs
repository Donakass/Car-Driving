using UnityEngine;
using UnityEngine.UI; // Required for UI components

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance;

    [SerializeField] private Text scoreText; // Reference to the UI Text element
    private int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int value)
    {
        score += value;
        Debug.Log($"Текущие очки: {score}");

        // Update the UI Text
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }
}
