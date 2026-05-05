using UnityEngine;

public class HarvesterStation : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform harvesterPosition;

    public void Interact()
    {
        if(GameManager.gm.Sombrium >= 10)
        {
            GameManager.gm.Sombrium -= 10;
            BaseManager.bm.levelUpBuilding(harvesterPosition);
        }
    }
}
