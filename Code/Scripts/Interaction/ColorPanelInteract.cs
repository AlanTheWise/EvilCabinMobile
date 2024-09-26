using UnityEngine;
using System.Collections.Generic;

public class ColorPanelInteract : MonoBehaviour
{
    [SerializeField] private GameObject bearPanel, foxPanel, otterPanel, owlPanel, sheepPanel, wolfPanel;
    private Dictionary<string, GameObject> colorPanels = new Dictionary<string, GameObject>();
    private string[] colors = new string[] { "bear", "fox", "otter", "owl", "sheep", "wolf" };
    private int colorIndex = 0;
    private GameObject previousPanel;

    void Start()
    {
        InitializeColorPanels();
        UpdateColorPanel();
    }

    private void InitializeColorPanels()
    {
        colorPanels.Add("bear", bearPanel);
        colorPanels.Add("fox", foxPanel);
        colorPanels.Add("otter", otterPanel);
        colorPanels.Add("owl", owlPanel);
        colorPanels.Add("sheep", sheepPanel);
        colorPanels.Add("wolf", wolfPanel);
    }

    public void ChangeColor()
    {
        if (previousPanel != null)
        {
            previousPanel.SetActive(false);
        }

        colorIndex = (colorIndex + 1) % colors.Length;
        UpdateColorPanel();
        ColorPanelManager.sharedInstance.CheckAnswer();
    }

    private void UpdateColorPanel()
    {
        var currentColor = colors[colorIndex];
        colorPanels[currentColor].SetActive(true);

        previousPanel = colorPanels[currentColor];
    }

    public string CurrentColor()
    {
        return colors[colorIndex];
    }
}
