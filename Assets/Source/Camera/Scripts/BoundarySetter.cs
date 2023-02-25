using UnityEngine;
using UnityEngine.Tilemaps;

public class BoundarySetter : MonoBehaviour
{
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private Tilemap _tilemap;

    private void Start()
    {
        float scale = _tilemap.transform.lossyScale.x;
        _cameraMovement.SetRectBounds(new Rect(_tilemap.localBounds.min * scale, _tilemap.localBounds.size * scale));
    }
}
