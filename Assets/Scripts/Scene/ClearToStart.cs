using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearToStart : MonoBehaviour
{
    void Update()
    {
        // 마우스 왼쪽 버튼 클릭 시
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
