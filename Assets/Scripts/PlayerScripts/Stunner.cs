using UnityEngine;

public class Stunner : MonoBehaviour
{
    private float _stunForce;
    [SerializeField] private SOEquipment stunnerData;
    private void Awake()
    {
        _stunForce = stunnerData.levels[GameManager.gm.StunnerLevel - 1];
    }
    public float GetStunForce() => _stunForce;
    public void LevelUp()
    {
        if(GameManager.gm.StunnerLevel < stunnerData.levels.Count && GameManager.gm.Sombrium >= GameManager.gm.StunnerNextLvlCost)
        {
            GameManager.gm.StunnerLevel++;
            _stunForce = stunnerData.levels[GameManager.gm.StunnerLevel - 1];
            GameManager.gm.Sombrium -= GameManager.gm.StunnerNextLvlCost;
            GameManager.gm.UpdateCosts();
        }
    }
}
