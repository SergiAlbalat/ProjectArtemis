using NUnit.Framework;
using UnityEngine;

public class BuildManager : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        BaseManager.bm.levelUpBuilding(transform);
    }
}
