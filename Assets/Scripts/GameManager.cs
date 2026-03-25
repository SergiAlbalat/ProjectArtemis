using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject capturedEnemy;
    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(this.gameObject);
            return;
        }
        gm = this;
        DontDestroyOnLoad(gameObject);
    }
    public void LoadBase()
    {
        SceneManager.LoadScene("Base");
    }
    public void CaptureEnemy(GameObject enemy)
    {
        capturedEnemy = enemy;
        LoadBase();
    }
    private void ShowUI()
    {

    }
}