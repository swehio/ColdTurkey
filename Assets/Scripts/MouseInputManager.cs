using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
    InteractableObject interactableObject;

    public static bool UseMouseInput = true;
    public void SetUseMouseInput(bool value) => UseMouseInput = value;

    private void Update()
    {
        print(UseMouseInput);

        if (!UseMouseInput) return;

        ShootRay();
        Interact();
    }

    private void Interact()
    {
        if (interactableObject == null) return;

        if (Input.GetMouseButtonDown(0))
            interactableObject.OnPointerClick();

    }

    private void ShootRay()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, Mathf.Infinity);

        if (hit.collider == null)
        {
            if (this.interactableObject != null)
            {
                this.interactableObject.OnPointerExit();
                this.interactableObject = null;
            }

            return;
        }


        if (hit.collider.TryGetComponent(out InteractableObject interactableObject))
        {
            if (this.interactableObject == null)
            {
                this.interactableObject = interactableObject;
                this.interactableObject.OnPointerEnter();
            }

            if (this.interactableObject == interactableObject) return;

            this.interactableObject.OnPointerExit();
            this.interactableObject = interactableObject;
            this.interactableObject.OnPointerEnter();
        }
    }
}
