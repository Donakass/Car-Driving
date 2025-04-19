using Unity.VisualScripting;
using UnityEngine;

public class FrameCollider : MonoBehaviour
{
    public LogicScript logic;
    public AssignFrame frame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        frame = GameObject.FindGameObjectWithTag("Frame").GetComponent<AssignFrame>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (frame.GetScoreValue() > 0)
            {
                logic.addScore(frame.GetScoreValue());
            }
            else
            {
                logic.subtractScore(frame.GetScoreValue());
            }
            Destroy(gameObject);
        }
    }
}
