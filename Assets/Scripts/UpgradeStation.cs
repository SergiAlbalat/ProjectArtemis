using UnityEngine;

public class UpgradeStation : Station
{
    public void LvlUpWeapon()
    {
        player.GetComponent<Weapon>().LevelUp();
    }
    public void LvlUpBoots()
    {
        player.GetComponent<Boots>().LevelUp();
    }
    public void LvlUpStunner()
    {
        player.Stunner.LevelUp();
    }
    public void LvlUpProtector()
    {
        player.Protector.LevelUp();
    }
}
