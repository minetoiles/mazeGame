using UnityEngine;

public class GearRotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 180f;  // 회전 속도 (도/초)

    void Update()
    {
        // -Z축 방향으로 계속 회전
        transform.Rotate(0f, 0f, -rotateSpeed * Time.deltaTime, Space.Self);
    }
}
