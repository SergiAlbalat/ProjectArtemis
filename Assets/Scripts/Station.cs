using UnityEngine;

public class Station : MonoBehaviour, IInteractable
{
    [SerializeField] private Canvas stationMenu;
    [SerializeField] private GameObject playerHUD;
    protected Player player;
    private CameraBehaviour cameraBehaviour;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        cameraBehaviour = GameObject.FindGameObjectWithTag("LookPoint").GetComponent<CameraBehaviour>();
    }
    public void Interact()
    {
        stationMenu.gameObject.SetActive(true);
        player.DisableMovement();
        Cursor.lockState = CursorLockMode.None;
        cameraBehaviour.DisableCamera();
        playerHUD.SetActive(false);
        playerHUD.SetActive(true);
    }
    public void CloseMenu()
    {
        stationMenu.gameObject.SetActive(false);
        player.EnableMovement();
        Cursor.lockState = CursorLockMode.Locked;
        cameraBehaviour.EnableCamera();
    }
}
