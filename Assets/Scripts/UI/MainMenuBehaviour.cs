using System.Collections;
using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] GameObject noSaveFile;
    private void Awake()
    {
        noSaveFile.SetActive(false);
    }
    public void TryLoadGame()
    {
        if (GameManager.gm.IsThereSaveFile())
        {
            GameManager.gm.LoadGame();
        }
        else
        {
            ShowNoLoad();
        }
    }
    private void ShowNoLoad()
    {
        noSaveFile.SetActive(true);
        StartCoroutine(HideNoSaveFile());
    }
    private IEnumerator HideNoSaveFile()
    {
        yield return new WaitForSeconds(1.5f);
        noSaveFile.SetActive(false);
    }
}
