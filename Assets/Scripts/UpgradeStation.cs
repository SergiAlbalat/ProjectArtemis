using UnityEngine;

public class UpgradeStation : MonoBehaviour, IInteractable
{
    [SerializeField] private Canvas upgradeUI;
    [SerializeField] private Player player;
    [SerializeField] private CameraBehaviour cameraBehaviour;
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
