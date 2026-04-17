using UnityEngine;

public class Protector : MonoBehaviour
{
    public float StunResistance;
    [SerializeField] private SOEquipment protectorData;
    private void Awake()
    {
        StunResistance = protectorData.levels[GameManager.gm.ProtectorLevel - 1];
    }
    public void LevelUp()
    {
        if(GameManager.gm.ProtectorLevel < protectorData.levels.Count && GameManager.gm.Sombrium >= GameManager.gm.ProtectorNextLvlCost)
        {
            GameManager.gm.ProtectorLevel++;
            StunResistance = protectorData.levels[GameManager.gm.ProtectorLevel - 1];
            GameManager.gm.Sombrium -= GameManager.gm.ProtectorNextLvlCost;
            GameManager.gm.UpdateCosts();
        }
    }
}
