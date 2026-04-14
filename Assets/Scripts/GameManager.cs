using System.Collections.Generic;
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
    public int Difficulty = 1;
    private float _lvlScaling = 1.5f;
    [SerializeField] private List<SOEnemies> enemyTypes;
    [SerializeField] private Player player;
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
        SceneManager.LoadScene("Battle1");
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
            Instantiate(player, new Vector3(0, 1, 0), Quaternion.identity);
        } if (scene == SceneManager.GetSceneByName("Battle1"))
        {
            GameObject enemy = Instantiate(enemyTypes[Difficulty - 1].prefab, Vector3.zero, Quaternion.identity);
            Player battlePlayer = Instantiate(player, new Vector3(0, 1, -30), Quaternion.identity);
            enemy.GetComponent<Enemy>().Player = battlePlayer;
        }
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void SetDifficulty(int difficulty)
    {
        Difficulty = difficulty;
        LoadBattle();
    }
    public void LvlUpBoots()
    {
        player.GetComponent<MoveBehaviour>().GetComponent<Boots>().LevelUp();
    }
    public void LvlUpWeapon()
    {
        player.GetComponent<Weapon>().LevelUp();
    }
}