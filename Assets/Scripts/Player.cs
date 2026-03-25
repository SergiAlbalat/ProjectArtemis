using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting;
[RequireComponent(typeof(MoveBehaviour))]

public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions, IStun
{
    [SerializeField] private float interactRange = 2f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Camera playerCamera;
    private InputSystem_Actions _inputActions;
    private MoveBehaviour _mB;
    private Vector2 _direction;
    public bool inRange = false;
    public Enemy nearEnemy = null;
    public bool stuned = false;
    private void Awake()
    {
        _mB = GetComponent<MoveBehaviour>();
        _inputActions = new InputSystem_Actions();
        _inputActions.Player.SetCallbacks(this);
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        _inputActions.Enable();
    }
    private void OnDisable()
    {
        _inputActions.Disable();
    }
    private void Update()
    {
        _mB.PlayerMove(new Vector3(_direction.x, 0, _direction.y));
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Debug.Log("interact");
        
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactableLayer))
        {
            Debug.Log(hit.collider.name);
            hit.collider.GetComponent<IInteractable>()?.Interact();
        }
    }
    public void StartStun()
    {
        StartCoroutine(Stun());
    }
    public IEnumerator Stun()
    {
        stuned = true;
        _inputActions.Disable();
        yield return new WaitForSeconds(5);
        stuned = false;
        _inputActions.Enable();
    }
   
    public void OnStunAttack(InputAction.CallbackContext context)
    {
        if(nearEnemy != null)
        {
            if (inRange && !nearEnemy.stuned)
            {
                nearEnemy.StartStun();
            }
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (nearEnemy != null)
            {
                if (inRange)
                {
                    nearEnemy.CurrentHP--;
                }
            }
        }
    }
}
