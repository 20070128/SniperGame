using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("コンポーネント参照")]
    [SerializeField] private Camera mainCamera;
    private Rigidbody rb;

    [Header("移動処理")]
    [SerializeField] private float moveSpeed = 5.0f;
    private Vector3 moveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 forward = mainCamera.transform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = mainCamera.transform.right;
        right.y = 0f;
        right.Normalize();

        moveDirection = forward * InputManager.Instance.MoveInput.y
            + right * InputManager.Instance.MoveInput.x;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(
            moveDirection.x * moveSpeed,
            rb.linearVelocity.y,
            moveDirection.z * moveSpeed
        );
    }
}