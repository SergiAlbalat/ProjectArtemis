using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField] protected GameObject menuPanel;
    private void Awake()
    {
        menuPanel.SetActive(false);
    }
    public virtual void OpenMenu()
    {
        menuPanel.SetActive(true);
    }
    public virtual void CloseMenu()
    {
        menuPanel.SetActive(false);
    }
}
