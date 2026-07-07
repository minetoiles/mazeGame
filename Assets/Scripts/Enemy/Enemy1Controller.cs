using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;     // 이동 속도
    [SerializeField] private float rotateSpeed = 180f; // 회전 속도 (도/초)

    private Vector3[] waypoints;
    private int currentPoint = 0;

    // 각 waypoint 도착 시 적용할 Y 회전값
    private float[] targetYRotations = { 0f, 90f, 180f, 270f };

    private void Start()
    {
        GetComponent<Enemy1Controller>().enabled = false;
        waypoints = new Vector3[]
        {
            new Vector3(3.2f, 2.27f, 55.2f),
            new Vector3(32.9f, 2.27f, 55.2f),
            new Vector3(32.9f, 2.27f, 44.3f),
            new Vector3(2.2f, 2.27f, 44.3f)
        };

        transform.position = waypoints[0];
        transform.rotation = Quaternion.Euler(0f, targetYRotations[0], 0f); // 시작 지점 회전
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

        // 목표 지점까지 거리
        float dist = Vector3.Distance(transform.position, targetPos);

        // 부드러운 Y 회전
        float targetY = targetYRotations[currentPoint];
        float currentY = transform.eulerAngles.y;
        float newY = Mathf.MoveTowardsAngle(currentY, targetY, rotateSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, newY, 0f);

        // 목표 지점 도달 체크
        if (dist < 0.1f)
        {
            currentPoint = (currentPoint + 1) % waypoints.Length;
        }
    }
}
