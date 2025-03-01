using UnityEngine;

public class Hint : InteractableObject
{
    [SerializeField] Dialogue dialogue;

    private void OnEnable()
    {
        dialogue.onDialogueEnd.AddListener(OnDialogueEnd);
    }


    void OnDialogueEnd()
    {
        // TEST
        TryGetComponent(out SpriteRenderer component);
        Color temp = component.color;
        temp.a = 0.5f;
        component.color = temp;
    }

    public override void OnPointerClick()
    {
        base.OnPointerClick();
        dialogue.gameObject.SetActive(true);
    }

}
