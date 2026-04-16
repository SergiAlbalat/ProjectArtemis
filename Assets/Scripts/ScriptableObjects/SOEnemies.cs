using UnityEngine;

[CreateAssetMenu(fileName = "SOEnemies", menuName = "Scriptable Objects/SOEnemies")]
public class SOEnemies : ScriptableObject
{
    public float MaxHP;
    public float SpeedDebuff;
    public float Timer;
    public float StunResistance;
    public GameObject prefab;
}
