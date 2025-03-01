using UnityEngine;

public class Hint : InteractableObject
{
    [SerializeField] Dialogue dialogue;
    [SerializeField] SpriteRenderer outline;

    private void OnEnable()
    {
        dialogue.onDialogueEnd.AddListener(OnDialogueEnd);
    }


    void OnDialogueEnd()
    {
        // TEST
        TryGetComponent(out SpriteRenderer component);
        Color temp = component.color;
        temp.a = 0.2f;
        component.color = temp;
    }

    public override void OnPointerEnter()
    {
        base.OnPointerEnter();
        outline.enabled = true;
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
        outline.enabled = false;
    }

    public override void OnPointerClick()
    {
        base.OnPointerClick();
        dialogue.gameObject.SetActive(true);
        outline.enabled = false;

    }

}
