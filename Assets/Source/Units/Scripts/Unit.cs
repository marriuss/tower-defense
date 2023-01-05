using UnityEngine;

[RequireComponent(typeof(SpriteFlipper))]
public class Unit : MonoBehaviour
{
    [SerializeField] private UnitStats _stats;

    public const int MinValue = 1;
    public const int MaxValue = 20;

    private SpriteFlipper _spriteFlipper;

    private void Awake()
    {
        _spriteFlipper = GetComponent<SpriteFlipper>();
    }

    public void TurnSide(bool turningLeft)
    {
        _spriteFlipper.TurnSide(turningLeft);   
    }

    public int GetValue()
    {
        // TODO
        return 1;
    }
}

