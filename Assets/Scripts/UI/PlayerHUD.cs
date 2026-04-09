using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ombriumCounter;
    private void Update()
    {
        ombriumCounter.text = GameManager.gm.Ombrium.ToString();
    }
}
