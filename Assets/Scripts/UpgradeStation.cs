using UnityEngine;

public class UpgradeStation : MonoBehaviour, IInteractable
{
    [SerializeField] private Canvas upgradeUI;
    private Player player;
    private CameraBehaviour cameraBehaviour;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        cameraBehaviour = GameObject.FindGameObjectWithTag("LookPoint").GetComponent<CameraBehaviour>();
    }
    public void Interact()
    {
        upgradeUI.gameObject.SetActive(true);
        player.DisableMovement();
        Cursor.lockState = CursorLockMode.None;
        cameraBehaviour.DisableCamera();
    }
    public void CloseMenu()
    {
        upgradeUI.gameObject.SetActive(false);
        player.EnableMovement();
        Cursor.lockState= CursorLockMode.Locked;
        cameraBehaviour.EnableCamera();
    }
}
