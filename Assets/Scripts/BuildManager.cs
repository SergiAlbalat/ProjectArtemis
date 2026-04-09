using NUnit.Framework;
using UnityEngine;

public class BuildManager : MonoBehaviour, IInteractable
{
    public virtual void Interact()
    {
        BaseManager.bm.levelUpBuilding(transform);
    }
}
