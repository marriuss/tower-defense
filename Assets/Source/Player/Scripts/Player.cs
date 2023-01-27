using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ProgressLoader _progressLoader;

    public Deck Deck { get; private set; }
    public Castle Castle { get; private set; }
    public Balance Balance { get; private set; }

    private void Awake()
    {
        Deck = new Deck();
        Castle = new Castle();
        Balance = new Balance();
    }

    private void OnEnable()
    {
        _progressLoader.ProgressLoaded += OnProgressLoaded;
    }

    private void OnDisable()
    {
        _progressLoader.ProgressLoaded -= OnProgressLoaded;
    }

    private void OnProgressLoaded(PlayerProgress progress)
    {
        Balance.AddMoney(progress.Money);
    }
}
