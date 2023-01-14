using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _dragSpeed = 1;

    private Camera _camera;
    private PointerEventData _pointerEventData;
    private CameraMovementActions _actions;
    private Vector2 _startPosition;
    private Rect _rectBounds;
    private bool _isDragging;
    private float _zPosition;
    private float _halfCameraWidth;
    private float _halfCameraHeight;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _actions = new CameraMovementActions();
        _pointerEventData = new PointerEventData(EventSystem.current);
        _zPosition = _camera.transform.position.z;
        _halfCameraWidth = _camera.GetWidth() / 2;
        _halfCameraHeight = _camera.GetHeight() / 2;
    }

    private void OnEnable()
    {
        _actions.Enable();
        _actions.ClickAndDrag.Click.started += (ctx) => OnStarted();
        _actions.ClickAndDrag.Click.canceled += (ctx) => OnCancelled();
    }

    private void OnDisable()
    {
        _actions.Disable();
        _actions.ClickAndDrag.Click.started -= (ctx) => OnStarted();
        _actions.ClickAndDrag.Click.canceled -= (ctx) => OnCancelled();
    }

    private void Update()
    {
        if (_isDragging)
        {
            Vector2 currentPosition = _camera.ScreenToWorldPoint(_actions.ClickAndDrag.Position.ReadValue<Vector2>());
            Vector2 cameraPosition = _camera.transform.position;
            Vector2 movement = currentPosition - _startPosition;

            Vector3 newPosition = Vector3.MoveTowards(cameraPosition, cameraPosition - movement, _dragSpeed * Time.deltaTime);
            newPosition.z = _zPosition;

            if (_rectBounds != null)
            {
                newPosition.x = Mathf.Clamp(newPosition.x, _rectBounds.xMin + _halfCameraWidth, _rectBounds.xMax - _halfCameraWidth);
                newPosition.y = Mathf.Clamp(newPosition.y, _rectBounds.yMin + _halfCameraHeight, _rectBounds.yMax - _halfCameraHeight);
            }

            _camera.transform.position = newPosition;
        }
    }

    public void SetRectBounds(Rect rect)
    {
        _rectBounds = rect;
    }

    private void OnStarted()
    {
        Vector2 clickPosition = _actions.ClickAndDrag.Position.ReadValue<Vector2>();

        if (CheckIsMovementAvailable(_startPosition) == false)
            return;

        _startPosition = _camera.ScreenToWorldPoint(clickPosition);
        _isDragging = true;
    }

    private void OnCancelled()
    {
        _isDragging = false;
    }

    private bool CheckIsMovementAvailable(Vector2 screenShotPosition)
    {
        _pointerEventData.position = screenShotPosition;
        return !EventSystem.current.CheckIsAnyElementPointed(_pointerEventData);
    }
}
