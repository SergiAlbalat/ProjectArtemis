using UnityEngine;

public class ExpeditionStation : MonoBehaviour, IInteractable
{
    [SerializeField] private Canvas expeditionMenu;
    private Player player;
    private CameraBehaviour cameraBehaviour;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        cameraBehaviour = GameObject.FindGameObjectWithTag("LookPoint").GetComponent<CameraBehaviour>();
    }
    public void Interact()
    {
        expeditionMenu.gameObject.SetActive(true);
        player.DisableMovement();
        Cursor.lockState = CursorLockMode.None;
        cameraBehaviour.DisableCamera();
    }
    public void CloseMenu()
    {
        expeditionMenu.gameObject.SetActive(false);
        player.EnableMovement();
        Cursor.lockState = CursorLockMode.Locked;
        cameraBehaviour.EnableCamera();
    }
}
