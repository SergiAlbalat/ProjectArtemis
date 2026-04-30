using UnityEngine;

public class ExpeditionStation : Station
{
    public void EasyDifficulty()
    {
        GameManager.gm.SetDifficulty(1);
    }
    public void MediumDifficulty()
    {
        GameManager.gm.SetDifficulty(2);
    }
    public void HardDifficulty()
    {
        GameManager.gm.SetDifficulty(3);
    }
}
