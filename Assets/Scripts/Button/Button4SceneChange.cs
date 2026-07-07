using UnityEngine;
using UnityEngine.SceneManagement;

public class Button4SceneChange : MonoBehaviour
{
    public void GoToMazeScene()
    {
        SceneManager.LoadScene("MazeMap3Scene");
    }
}
