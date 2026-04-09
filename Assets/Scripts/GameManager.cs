using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    [SerializeField] private BaseManager bm;
    public SOEnemies capturedEnemy;
    public int WeaponLevel = 1;
    public int BootsLevel = 1;
    public int Ombrium = 0;
    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(this.gameObject);
            return;
        }
        gm = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
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
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene == SceneManager.GetSceneByName("Base"))
        {
            bm.LoadBase();
        }
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}