using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    private void Awake()
    {
        menuPanel.SetActive(false);
    }
    public void OpenMenu()
    {
        menuPanel.SetActive(true);
    }
    public void CloseMenu()
    {
        menuPanel.SetActive(false);
    }
}
