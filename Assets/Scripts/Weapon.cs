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
}
