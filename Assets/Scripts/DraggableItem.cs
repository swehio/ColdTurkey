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

        RaycastHit2D[] hits = Physics2D.RaycastAll(GetMouseWorldPosition(), Vector2.zero);
        RaycastHit2D closestHit = new RaycastHit2D();
        float closestDistance = Mathf.Infinity;

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.gameObject.GetComponent<DraggableItem>() != null)
            {
                float distance = Vector2.Distance(hit.point, GetMouseWorldPosition());
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestHit = hit;
                }
            }
        }

        if (closestHit.collider != null)
        {
            offset = closestHit.collider.transform.position - GetMouseWorldPosition();
            closestHit.collider.GetComponent<DraggableItem>().StartDragging(); 
        }
    }

    private void StartDragging()
    {
        isDragging = true;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}