using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[Serializable]
public class SaveFile
{
    public int WeaponLevel;
    public int BootsLevel;
    public int StunnerLevel;
    public int ProtectorLevel;
    public int Sombrium;
    public List<BuildingPoint> BuildingPoints;
    public List<StoredEnemyEntry> EnemiesContained;
    public SaveFile()
    {
        WeaponLevel = GameManager.gm.WeaponLevel;
        BootsLevel = GameManager.gm.BootsLevel;
        StunnerLevel = GameManager.gm.StunnerLevel;
        ProtectorLevel = GameManager.gm.ProtectorLevel;
        Sombrium = GameManager.gm.Sombrium;
        BuildingPoints = BaseManager.bm.GetBuildingPoints();
        EnemiesContained = BaseManager.bm.GetEnemiesContained().storedEnemies;
    }
}
