using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    [SerializeField] private BaseManager bm;
    public SOEnemies capturedEnemy;
    public int capturedEnemyModel;
    public int WeaponLevel = 1;
    public int BootsLevel = 1;
    public int StunnerLevel = 1;
    public int ProtectorLevel = 1;
    public int Sombrium = 0;
    public int WeaponNextLvlCost;
    public int BootsNextLvlCost;
    public int StunnerNextLvlCost;
    public int ProtectorNextLvlCost;
    public int Difficulty = 1;
    private float _lvlScaling = 1.5f;
    [SerializeField] private List<SOEnemies> enemyTypes;
    [SerializeField] private Player player;
    private string _saveFilePath;
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
        _saveFilePath = Application.persistentDataPath + "/savefile.json";
    }
    public void LoadBase()
    {
        SceneManager.LoadScene("Base");
    }
    public void LoadBattle()
    {
        SceneManager.LoadScene("Battle1");
    }
    public void CaptureEnemy(SOEnemies enemy, int model)
    {
        capturedEnemy = enemy;
        capturedEnemyModel = model;
        Debug.Log("Capturando");
        LoadBase();
    }
    public void UpdateCosts()
    {
        WeaponNextLvlCost = (WeaponLevel * _lvlScaling).ConvertTo<int>();
        BootsNextLvlCost = (BootsLevel * _lvlScaling).ConvertTo<int>();
        StunnerNextLvlCost = (StunnerLevel * _lvlScaling).ConvertTo<int>();
        ProtectorNextLvlCost = (ProtectorLevel * _lvlScaling).ConvertTo<int>();
    }
    private void ShowUI()
    {

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Base")
        {
            bm.LoadBase();
            Instantiate(player, new Vector3(0, 1, 0), Quaternion.identity);
        }

        if (scene.name == "Battle1")
        {
            Player battlePlayer = Instantiate(player, new Vector3(0, 1, -30), Quaternion.identity);
            Vector3 spawnPoint;
            GameObject enemy;
            if (TryGetNavMeshSpawnPoint(Vector3.zero, 100f, out spawnPoint))
            {
                enemy = Instantiate(enemyTypes[Difficulty - 1].prefab, spawnPoint, Quaternion.identity);
            }
            else
            {
                enemy = Instantiate(enemyTypes[Difficulty - 1].prefab, Vector3.zero, Quaternion.identity);
            }
            battlePlayer.nearEnemy = enemy.GetComponent<Enemy>();
        }
    }

    private bool TryGetNavMeshSpawnPoint(Vector3 center, float radius, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * radius;
            randomPoint.y = center.y;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 3f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
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
    public void SaveGame()
    {
        SaveFile data = new SaveFile();
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(_saveFilePath, json);
    }
    public void LoadGame()
    {
        if(File.Exists(_saveFilePath))
        {
            string json = File.ReadAllText(_saveFilePath);
            SaveFile data = JsonUtility.FromJson<SaveFile>(json);
            WeaponLevel = data.WeaponLevel;
            BootsLevel = data.BootsLevel;
            StunnerLevel = data.StunnerLevel;
            ProtectorLevel = data.ProtectorLevel;
            Sombrium = data.Sombrium;
            bm.LoadBuilPoints(data.BuildingPoints);
            bm.LoadContainedEnemies(data.EnemiesContained);
            LoadBase();
        }
    }
    public void NewGame()
    {
        bm.DeleteConainedEnemies();
        LoadBase();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public bool IsThereSaveFile() => File.Exists(_saveFilePath);
}