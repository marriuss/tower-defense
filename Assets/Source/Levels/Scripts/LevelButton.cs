using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButton : WorkButton
{
    public UnityAction<LevelButton> ButtonClicked;

    [SerializeField] private TMP_Text _levelNumberText;
    [SerializeField] private LevelInfo _levelInfo;

    public void Init(LevelInfo levelInfo)
    {
        _levelInfo = levelInfo;
        _levelNumberText.text = _levelInfo.Id.ToString();
    }

    public LevelInfo LevelInfo => _levelInfo;

    protected override void OnButtonClick()
    {
        ButtonClicked?.Invoke(this);
    }
}
