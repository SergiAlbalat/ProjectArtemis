using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject tutorial1;
    [SerializeField] private GameObject tutorial2;
    [SerializeField] private GameObject tutorial3;
    [SerializeField] private GameObject tutorial4;
    private void Awake()
    {
        menuPanel.SetActive(false);
    }
    public void OpenMenu()
    {
        menuPanel.SetActive(true);
        StartTutorial1();
    }
    public void CloseMenu()
    {
        menuPanel.SetActive(false);
    }
    public void StartTutorial1()
    {
        tutorial1.SetActive(true);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
    }
    public void StartTutorial2()
    {
        tutorial2.SetActive(true);
        tutorial1.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
    }
    public void StartTutorial3()
    {
        tutorial3.SetActive(true);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial1.SetActive(false);
    }
    public void StartTutorial4()
    {
        tutorial4.SetActive(true);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
    }
}
