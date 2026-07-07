using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotateSpeed = 90f; // 회전 속도 (도/초)

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.freezeRotation = true; // 물리 회전 방지
    }

    void FixedUpdate()
    {
        Vector3 dir = Vector3.zero;
        float rotation = 0f;

        // 이동 방향
        if (Input.GetKey(KeyCode.UpArrow))
            dir = transform.forward;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -transform.forward;

        // 회전
        if (Input.GetKey(KeyCode.LeftArrow))
            rotation = -90f;
        else if (Input.GetKey(KeyCode.RightArrow))
            rotation = 90f;

        // Rigidbody 이동
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);

        // 부드러운 회전
        if (rotation != 0f)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, transform.eulerAngles.y + rotation, 0f);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime));
        }
    }
}
