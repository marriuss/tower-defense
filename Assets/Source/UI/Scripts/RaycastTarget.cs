using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(CanvasRenderer))]
public class RaycastTarget : Graphic
{
    protected override void Awake()
    {
        enabled = false;
    }

    public override void SetMaterialDirty() { return; }
    public override void SetVerticesDirty() { return; }
}