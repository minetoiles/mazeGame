using UnityEngine;

public class Enemy3Controller : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotateSpeed = 180f;

    private Vector3[] waypoints;
    private int currentPoint = 0;

    private void Start()
    {
        waypoints = new Vector3[]
        {
            new Vector3(101.9f, 2.27f, 25.5f),
            new Vector3(132.7f, 2.27f, 25.5f),
            new Vector3(132.7f, 2.27f, 7f),
            new Vector3(101.9f, 2.27f, 7f)
        };

        transform.position = waypoints[0];
    }

    private void Update()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        Vector3 targetPos = waypoints[currentPoint];

        // 이동
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );

        // 이동 방향 회전
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

        // 목표 지점 도달 시 다음 포인트
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % waypoints.Length;
        }
    }
}
