using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MoveBehaviour))]

public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions, IStun
{
    [SerializeField] private float interactRange = 2f;
    [SerializeField] private LayerMask interactableLayer;
    private AnimationBehaviour _aB;
    private Camera playerCamera;
    private InputSystem_Actions _inputActions;
    private MoveBehaviour _mB;
    private Weapon _currentWeapon;
    private Vector2 _direction;
    public bool inRange = false;
    public Enemy nearEnemy = null;
    public bool stuned = false;
    public Stunner Stunner;
    public Protector Protector;
    public float StunTime = 5;
    private void Awake()
    {
        _mB = GetComponent<MoveBehaviour>();
        _aB = GetComponent<AnimationBehaviour>();
        _inputActions = new InputSystem_Actions();
        _inputActions.Player.SetCallbacks(this);
        _currentWeapon = GetComponent<Weapon>();
        Protector = GetComponent<Protector>();
        Cursor.lockState = CursorLockMode.Locked;
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Stunner = GetComponent<Stunner>();
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
        StartCoroutine(Stun(StunTime - Protector.StunResistance));
    }
    public IEnumerator Stun(float time)
    {
        stuned = true;
        _inputActions.Disable();
        yield return new WaitForSeconds(time);
        stuned = false;
        _inputActions.Enable();
    }
   
    public void OnStunAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _mB.TryStun();
            if (nearEnemy != null)
            {
                if (inRange && !nearEnemy.stuned)
                {
                    nearEnemy.StartStun();
                }
            }
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _mB.TryAttack();
            if (nearEnemy != null)
            {
                if (inRange)
                {
                    _currentWeapon.Attack(nearEnemy);
                }
            }
        }
    }
    public void AjustMovement(float debuff)
    {
        _mB.AjustVelocity(debuff);
    }
    public void DisableMovement()
    {
        _inputActions.Disable();
    }
    public void EnableMovement()
    {
        _inputActions.Enable();
    }

    public void OnKill(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            nearEnemy.TryKill();
        }
    }

    public void OnSave(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            GameManager.gm.SaveGame();
        }
    }

    public void OnLoad(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            GameManager.gm.LoadGame();
        }
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _aB.PlayerLeft(true);
        }
        else
        {
            _aB.PlayerLeft(false);
        }
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _aB.PlayerRight(true);
        }
        else
        {
            _aB.PlayerRight(false);
        }
    }

    public void OnBack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _aB.PlayerBack(true);
        }
        else
        {
            _aB.PlayerBack(false);
        }
    }
}
