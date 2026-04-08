using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float _damage;
    [SerializeField] private SOEquipment weaponsData;
    private void Start()
    {
        Debug.Log(GameManager.gm.WeaponLevel - 1);
        _damage = weaponsData.levels[GameManager.gm.WeaponLevel - 1];
    }
    public void Attack(Enemy enemy)
    {
        enemy.OnHurt(_damage);
    }
    public void LevelUp()
    {
        if(GameManager.gm.WeaponLevel < weaponsData.levels.Count)
        {
            GameManager.gm.WeaponLevel++;
            _damage = weaponsData.levels[GameManager.gm.WeaponLevel - 1];
        }
    }
}
