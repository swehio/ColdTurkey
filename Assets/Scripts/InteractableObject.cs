using UnityEngine;
using EditorAttributes;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] UnityEvent onPointerEnter;
    [SerializeField] UnityEvent onPointerExit;
    [SerializeField] UnityEvent onPointerClick;

    public void OnPointerEnter()
    {
        print("Pointer Enter " + name);
        onPointerEnter?.Invoke();
    }
    public void OnPointerExit()
    {
        print("Pointer Exit " + name);
        onPointerExit?.Invoke();
    }
    public void OnPointerClick()
    {
        print("Pointer Click");
        onPointerClick?.Invoke();
    }

}
