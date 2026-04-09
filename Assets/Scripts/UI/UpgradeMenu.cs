using TMPro;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponText;
    [SerializeField] private TextMeshProUGUI weaponInfo;
    [SerializeField] private TextMeshProUGUI bootsText;
    [SerializeField] private TextMeshProUGUI bootsInfo;
    [SerializeField] private SOEquipment weaponsData;
    [SerializeField] private SOEquipment bootsData;
    private void Update()
    {
        weaponText.text = GameManager.gm.WeaponNextLvlCost + " - Upgrade Weapon: LVL " + GameManager.gm.WeaponLevel;
        bootsText.text = GameManager.gm.BootsNextLvlCost + " - Upgrade Boots: LVL " + GameManager.gm.BootsLevel;
        weaponInfo.text = "Current Damage: " + weaponsData.levels[GameManager.gm.WeaponLevel - 1];
        bootsInfo.text = "Current Speed Boost: +" + bootsData.levels[GameManager.gm.BootsLevel - 1] + "%";
    }
}