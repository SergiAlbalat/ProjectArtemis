using NUnit.Framework;
using UnityEngine;

public class BuildManager : MonoBehaviour, IInteractable
{
    public virtual void Interact()
    {
        if(GameManager.gm.Sombrium >= 2)
        {
            GameManager.gm.Sombrium -= 2;
            BaseManager.bm.levelUpBuilding(transform);
        }
    }
}
