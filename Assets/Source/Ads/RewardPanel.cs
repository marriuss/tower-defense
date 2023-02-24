using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPanel : MonoBehaviour
{
    [SerializeField] private Button[] _openButtons;
    [SerializeField] private Button _okButton;
    [SerializeField] private Button _cancelButton;
    [SerializeField] private GameObject _panelView;
    [SerializeField] private RewardedAds _rewardedAds;

    private void OnEnable()
    {
        for (int i = 0; i < _openButtons.Length; i++)
        {
            _openButtons[i].onClick.AddListener(OnOpenButtonClicked);
        }

        _okButton.onClick.AddListener(OnOkButtonClicked);
        _cancelButton.onClick.AddListener(OnCancelButtonClicked);
    }

    private void OnDisable()
    {
        for (int i = 0; i < _openButtons.Length; i++)
        {
            _openButtons[i].onClick.RemoveListener(OnOpenButtonClicked);
        }

        _okButton.onClick.RemoveListener(OnOkButtonClicked);
        _cancelButton.onClick.RemoveListener(OnCancelButtonClicked);
    }

    private void OnOpenButtonClicked()
    {
        _panelView.SetActive(true);
    }

    private void OnOkButtonClicked()
    {
        _rewardedAds.Show();
        _panelView.SetActive(false);
    }

    private void OnCancelButtonClicked()
    {
        _panelView.SetActive(false);
    }
}
