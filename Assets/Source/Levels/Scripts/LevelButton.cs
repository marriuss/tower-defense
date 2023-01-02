using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelNumberText;
    [SerializeField] private LevelInfo _levelInfo;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    public void Init(LevelInfo levelInfo)
    {
        _levelInfo = levelInfo;
        _levelNumberText.text = _levelInfo.Identifier.ToString();
    }

    public LevelInfo LevelInfo => _levelInfo;

    private void OnButtonClicked()
    {
        // TODO: Load level
    }
}
