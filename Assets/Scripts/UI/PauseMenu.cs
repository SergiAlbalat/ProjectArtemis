using UnityEngine;

public class PauseMenu : MenuBehaviour
{
    private SettingsMenu _settingsMenu;
    [SerializeField] private GameObject pauseMenuPanel;
    private void Awake()
    {
        pauseMenuPanel.SetActive(true);
        _settingsMenu = GetComponent<SettingsMenu>();
    }
    public override void CloseMenu()
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
        pauseMenuPanel.SetActive(false);
    }
    public void CloseSettings()
    {
        _settingsMenu.CloseMenu();
        pauseMenuPanel.SetActive(true);
    }
    public void ExitGame()
    {
        GameManager.gm.ExitGame();
    }
}
