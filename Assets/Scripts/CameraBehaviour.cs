using UnityEngine;
using UnityEngine.InputSystem;

public class CameraBehaviour : MonoBehaviour, InputSystem_Actions.ICameraActions
{
    private InputSystem_Actions _controls;
    private Vector2 _lookInput;

    [SerializeField] private Transform player;
    [SerializeField] private float sensitivity = 0.01f;
    [SerializeField] private float topClamp = 70f;
    [SerializeField] private float bottomClamp = -30f;

    private float _pitch;
    private float _yaw;

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new InputSystem_Actions();
            _controls.Camera.SetCallbacks(this);
        }
        _controls.Camera.Enable();
    }

    private void OnDisable()
    {
        _controls.Camera.Disable();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if (_lookInput.sqrMagnitude < 0.01f) return;

        _yaw += _lookInput.x * sensitivity;
        _pitch -= _lookInput.y * sensitivity;

        _pitch = Mathf.Clamp(_pitch, bottomClamp, topClamp);

        player.rotation = Quaternion.Euler(0, _yaw, 0.0f);
        transform.rotation = Quaternion.Euler(_pitch, _yaw, 0.0f);
    }
}
