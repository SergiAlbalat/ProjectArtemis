using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private SettingsMenu _settingsMenu;
    [SerializeField] private GameObject menuPanel;
    private void Awake()
    {
        gameObject.SetActive(false);
        menuPanel.SetActive(true);
        _settingsMenu = GetComponent<SettingsMenu>();
    }
    public void CloseMenu()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void SaveGame()
    {
        GameManager.gm.SaveGame();
    }
    public void OpenSettings()
    {
        _settingsMenu.OpenMenu();
        menuPanel.SetActive(false);
    }
    public void CloseSettings()
    {
        _settingsMenu.CloseMenu();
        menuPanel.SetActive(true);
    }
}
