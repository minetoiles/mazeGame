using UnityEngine;
using UnityEngine.SceneManagement;

public class Button3SceneChange : MonoBehaviour
{
    public void GoToMazeScene()
    {
        SceneManager.LoadScene("MazeMap1Scene");
    }
}
