using System;
using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ombriumCounter;
    [SerializeField] private GameObject noHarvesterPanel;
    private void Awake()
    {
        noHarvesterPanel.SetActive(false);
    }
    private void Update()
    {
        ombriumCounter.text = GameManager.gm.Sombrium.ToString();
    }
    public void ShowNoHarvesterPanel()
    {
        noHarvesterPanel.SetActive(true);
        Invoke("HideNoHarvesterPanel", 3f);
    }
    private void HideNoHarvesterPanel()
    {
        noHarvesterPanel.SetActive(false);
    }
}
