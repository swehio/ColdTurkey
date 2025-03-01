using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    private bool isDragging = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryStartDragging();
        }

        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    private void TryStartDragging()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        RaycastHit2D hit = Physics2D.Raycast(GetMouseWorldPosition(), Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            offset = transform.position - GetMouseWorldPosition();
            isDragging = true;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; 
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}