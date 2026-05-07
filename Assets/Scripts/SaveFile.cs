using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[Serializable]
public class SaveFile
{
    private int _weaponLevel;
    private int _bootsLevel;
    private int _stunnerLevel;
    private int _protectorLevel;
    private int _sombrium;
    private List<BuildingPoint> _buildingPoints;
    private EnemiesContained _enemiesContained;
    public SaveFile()
    {
        _weaponLevel = GameManager.gm.WeaponLevel;
        _bootsLevel = GameManager.gm.BootsLevel;
        _stunnerLevel = GameManager.gm.StunnerLevel;
        _protectorLevel = GameManager.gm.ProtectorLevel;
        _sombrium = GameManager.gm.Sombrium;
        
    }
}
