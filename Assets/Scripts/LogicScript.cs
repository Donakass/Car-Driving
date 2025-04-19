using UnityEngine;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    [ContextMenu("Add Score")]
    public void addScore(int number)
    {
        playerScore += number;
    }
    [ContextMenu("Subtract Score")]
    public void subtractScore(int number)
    {
        playerScore -= number;
    }
}
