using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEnemiesDiffiicultyStructure", menuName = "Scriptable Objects/SOEnemiesDiffiicultyStructure")]
public class SOEnemiesDiffiicultyStructure : ScriptableObject
{
    public List<SOEnemies> enemyTypes;
}
