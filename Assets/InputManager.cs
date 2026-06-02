using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { private set; get; }
    private InputSystem_Actions inputActions;

    //Action‚Ì“ü—Íˆ—
    public Vector2 LookInput { private set; get; }
    public Vector2 MoveInput { private set; get; }
    
    void Awake()
    {
        if (Instance != null) { Destroy(gameObject);return; }
        Instance = this;
        inputActions = new InputSystem_Actions();
    }

    void OnEnable() => inputActions.Enable();
    void OnDisable() => inputActions.Disable();

    void Update()
    {
        LookInput = inputActions.Player.Look.ReadValue<Vector2>();
        MoveInput = inputActions.Player.Move.ReadValue<Vector2>();
    }
}
