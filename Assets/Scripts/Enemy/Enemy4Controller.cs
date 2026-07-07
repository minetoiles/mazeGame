using UnityEngine;

public class Enemy4Controller : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;     // 이동 속도
    [SerializeField] private float rotateSpeed = 180f; // 회전 속도 (도/초)

    private Vector3[] waypoints;
    private int currentPoint = 0;

    private void Start()
    {
        GetComponent<Enemy4Controller>().enabled = false;
        // 이동 경로 설정 (Enemy4)
        waypoints = new Vector3[]
        {
            new Vector3(92.9f, 2.27f, 36.1f),
            new Vector3(92.9f, 2.27f, 66f),
            new Vector3(83f, 2.27f, 66f),
            new Vector3(83f, 2.27f, 86.4f),
            new Vector3(73.9f, 2.27f, 86.4f),
            new Vector3(73.9f, 2.27f, 36.1f)
        };

        // 시작 위치
        transform.position = waypoints[0];
    }

    private void Update()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        Vector3 targetPos = waypoints[currentPoint];

        // --- 이동 ---
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );

        // --- 이동 방향 회전 ---
        Vector3 direction = (targetPos - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
            );
        }

        // --- 목표 지점 도달 시 다음 포인트로 ---
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % waypoints.Length;
        }
    }
}
