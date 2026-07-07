using UnityEngine;
using UnityEngine.SceneManagement;

public class Button1SceneChange : MonoBehaviour
{
    public void GoToMazeScene()
    {
        SceneManager.LoadScene("MazeFollow1Scene");
    }
}
