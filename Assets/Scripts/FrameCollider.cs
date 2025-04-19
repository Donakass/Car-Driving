using UnityEngine;

public class FrameCollider : MonoBehaviour
{
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            logic.addScore();
            Destroy(gameObject);
        }
    }
}
