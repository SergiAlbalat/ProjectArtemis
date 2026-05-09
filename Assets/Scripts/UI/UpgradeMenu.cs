using TMPro;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponText;
    [SerializeField] private TextMeshProUGUI weaponInfo;
    [SerializeField] private TextMeshProUGUI bootsText;
    [SerializeField] private TextMeshProUGUI bootsInfo;
    [SerializeField] private TextMeshProUGUI stunnerText;
    [SerializeField] private TextMeshProUGUI stunnerInfo;
    [SerializeField] private TextMeshProUGUI protectorText;
    [SerializeField] private TextMeshProUGUI protectorInfo;
    [SerializeField] private SOEquipment weaponsData;
    [SerializeField] private SOEquipment bootsData;
    [SerializeField] private SOEquipment stunnerData;
    [SerializeField] private SOEquipment protectorData;
    private void Update()
    {
        weaponText.text = GameManager.gm.WeaponLevel != weaponsData.levels.Count ? "UPGRADE WEAPON\nCost: " + GameManager.gm.WeaponNextLvlCost + "\n\nLVL: " + GameManager.gm.WeaponLevel : "UPGRADE WEAPON\nCost: MAXED\n\nLVL: " + GameManager.gm.WeaponLevel;
        bootsText.text = GameManager.gm.BootsLevel != bootsData.levels.Count ? "UPGRADE BOOTS\nCost: " + GameManager.gm.BootsNextLvlCost + "\n\nLVL: " + GameManager.gm.BootsLevel : "UPGRADE BOOTS\nCost: MAXED\n\nLVL: " + GameManager.gm.BootsLevel;
        stunnerText.text = GameManager.gm.StunnerLevel != stunnerData.levels.Count ? "LVL: " + GameManager.gm.StunnerLevel + "\n\nCost: " + GameManager.gm.StunnerNextLvlCost + "\nUPGRADE STUNNER" : "LVL: " + GameManager.gm.StunnerLevel + "\n\nCost: MAXED\nUPGRADE STUNNER";
        protectorText.text = GameManager.gm.ProtectorLevel != protectorData.levels.Count ? "LVL: " + GameManager.gm.ProtectorLevel + "\n\nCost: " + GameManager.gm.ProtectorNextLvlCost + "\nUPGRADE PROTECTOR" : "LVL: " + GameManager.gm.ProtectorLevel + "\n\nCost: MAXED\nUPGRADE PROTECTOR";
        weaponInfo.text = "Current Damage: " + weaponsData.levels[GameManager.gm.WeaponLevel - 1];
        bootsInfo.text = "Current Speed Boost: +" + bootsData.levels[GameManager.gm.BootsLevel - 1] * 100 + "%";
        stunnerInfo.text = "Current Stun Time: " + stunnerData.levels[GameManager.gm.StunnerLevel - 1] + " seconds";
        protectorInfo.text = "Current Stun Resistance " + protectorData.levels[GameManager.gm.ProtectorLevel - 1] + " seconds";
    }
}