using Unity.VisualScripting;
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
    public int WeaponNextLvlCost;
    public int BootsNextLvlCost;
    private float _lvlScaling = 1.5f;
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
        UpdateCosts();
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
    public void UpdateCosts()
    {
        WeaponNextLvlCost = (WeaponLevel * _lvlScaling).ConvertTo<int>();
        BootsNextLvlCost = (BootsLevel * _lvlScaling).ConvertTo<int>();
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