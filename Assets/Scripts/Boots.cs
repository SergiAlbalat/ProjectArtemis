using UnityEngine;

public class Boots : MonoBehaviour
{
    [SerializeField] private SOEquipment bootsData;
    public float SpeedBuff;
    private void Start()
    {
        SpeedBuff = bootsData.levels[GameManager.gm.BootsLevel - 1];
    }
    public void LevelUp()
    {
        if(GameManager.gm.BootsLevel < bootsData.levels.Count)
        {
            GameManager.gm.BootsLevel++;
            SpeedBuff = bootsData.levels[GameManager.gm.BootsLevel - 1];
        }
    }
}
