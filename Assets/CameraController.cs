using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("コンポーネント参照")]
    //Player角度変更
    [SerializeField] private Transform playerTransform;
    [Header("Camera角度設定")]
    //角度制限
    [SerializeField] private float xMinRotation = -90f;
    [SerializeField] private float xMaxRotation = 90f;
    [SerializeField] private float yMinRotation = -90f;
    [SerializeField] private float yMaxRotation = 90f;
    //Camera速度
    [SerializeField] private float senstivity = 0.1f;
    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookInput = InputManager.Instance.LookInput;
        xRotation -= lookInput.y * senstivity;
        xRotation = Mathf.Clamp(xRotation, xMinRotation, xMaxRotation);
        yRotation += lookInput.x * senstivity;
        yRotation = Mathf.Clamp(yRotation, yMinRotation, yMaxRotation);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
