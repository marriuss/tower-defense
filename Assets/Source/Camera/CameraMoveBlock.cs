using System.Collections.Generic;
using UnityEngine;

public class CameraMoveBlock : MonoBehaviour
{
    [SerializeField] private Panel[] _panels;
    [SerializeField] private CameraMovement _cameraMovement;

    private List<Panel> _openedPanels;

    private void OnEnable()
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].PanelOpened += OnPanelOpened;
            _panels[i].PanelClosed += OnPanelClosed;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].PanelOpened -= OnPanelOpened;
            _panels[i].PanelClosed -= OnPanelClosed;
        }
    }

    private void Start()
    {
        _openedPanels = new List<Panel>();
    }

    private void OnPanelOpened(Panel panel)
    {
        _openedPanels.Add(panel);
        UpdateCameraMove();
    }

    private void OnPanelClosed(Panel panel)
    {
        _openedPanels.Remove(panel);
        UpdateCameraMove();
    }

    private void UpdateCameraMove()
    {
        if (_openedPanels.Count > 0)
        {
            _cameraMovement.enabled = false;
            return;
        }

        _cameraMovement.enabled = true;
    }
}
