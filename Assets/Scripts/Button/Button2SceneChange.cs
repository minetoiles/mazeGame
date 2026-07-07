using UnityEngine;
using UnityEngine.SceneManagement;

public class Button2SceneChange : MonoBehaviour
{
    public void GoToMazeScene()
    {
        SceneManager.LoadScene("MazeFollow3Scene");
    }
}
