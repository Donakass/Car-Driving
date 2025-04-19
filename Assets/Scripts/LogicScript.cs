using UnityEngine;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    [ContextMenu("Add Score")]
    public void addScore()
    {
        playerScore += Random.Range(1, 100);
        scoreText.text = playerScore.ToString();
    }
    [ContextMenu("Subtract Score")]
    public void subtractScore()
    {
        playerScore -= Random.Range(1, 100);
        scoreText.text = playerScore.ToString();
    }
}
