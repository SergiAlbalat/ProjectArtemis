using UnityEngine;

public class ExpeditionStation : MonoBehaviour, IInteractable
{
    [SerializeField] private Canvas expeditionMenu;
    [SerializeField] private Player player;
    [SerializeField] private CameraBehaviour cameraBehaviour;
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
