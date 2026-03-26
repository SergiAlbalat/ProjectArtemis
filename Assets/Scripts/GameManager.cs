using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public SOEnemies capturedEnemy;
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
    public void LoadBattle()
    {
        SceneManager.LoadScene("Battle");
    }
    public void CaptureEnemy(SOEnemies enemy)
    {
        capturedEnemy = enemy;
        Debug.Log("Capturando");
        LoadBase();
    }
    private void ShowUI()
    {

    }
}