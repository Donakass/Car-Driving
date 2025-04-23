using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public int sceneNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Transition()
    {
        Debug.Log("Transition method called");
        SceneManager.LoadScene(sceneNum);
    }

}
