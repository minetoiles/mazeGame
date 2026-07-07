using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    [SerializeField] AudioSource success;           // 성공 사운드
    [SerializeField] GameObject player; // 플레이어

    private bool isEnding = false;
    private void OnTriggerEnter(Collider other)
    {
        if (isEnding) return;

        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EndProcess());
        }
    }

    private System.Collections.IEnumerator EndProcess()
    {
        isEnding = true;

        // Player 조작 비활성화
        if (player != null)
            player.GetComponent<PlayerControl>().enabled = false;

        // 사운드 재생
        if (success != null)
            success.Play();

        // 사운드 재생이 끝날 때까지 기다림
        if (success != null)
            yield return new WaitForSeconds(success.clip.length);
        else
            yield return new WaitForSeconds(1f); // 예비 대기

        // 엔딩 씬 로드
        SceneManager.LoadScene("ClearScene");
    }
}
