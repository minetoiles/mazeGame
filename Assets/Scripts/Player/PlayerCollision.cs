using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameObject checkmate1;
    [SerializeField] GameObject checkmate2;
    [SerializeField] GameObject checkmate3;
    [SerializeField] GameObject checkmate4;

    [SerializeField] AudioSource audioSource;
    [SerializeField] MonoBehaviour playerController;

    private Rigidbody rb;
    private bool isProcessing = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isProcessing) return;

        GameObject target = null;

        if (collision.gameObject.CompareTag("Gear1")) target = checkmate1;
        else if (collision.gameObject.CompareTag("Gear2")) target = checkmate2;
        else if (collision.gameObject.CompareTag("Gear3")) target = checkmate3;
        else if (collision.gameObject.CompareTag("Gear4")) target = checkmate4;

        if (target != null)
        {
            StartCoroutine(TeleportRB(target.transform.position));
        }
    }

    private System.Collections.IEnumerator TeleportRB(Vector3 targetPos)
    {
        isProcessing = true;

        // 1) PlayerControl OFF
        if (playerController != null)
            playerController.enabled = false;

        // 2) 사운드 재생
        if (audioSource != null)
            audioSource.Play();

        // 3) 물리 동작 정지
        rb.isKinematic = true;

        // 4) 이동 (안전하게)
        rb.position = targetPos;
        rb.rotation = Quaternion.identity;

        // 5) 속도는 바로 0으로 만들어도 오류 없음 (Kinematic에도 velocity는 가능)
        rb.linearVelocity = Vector3.zero;

        // 6) 고정 프레임까지 기다린 뒤 다시 물리 활성화
        yield return new WaitForFixedUpdate();
        rb.isKinematic = false;

        // 7) 다음 프레임에 컨트롤러 ON
        yield return null;
        if (playerController != null)
            playerController.enabled = true;

        isProcessing = false;
    }
}
