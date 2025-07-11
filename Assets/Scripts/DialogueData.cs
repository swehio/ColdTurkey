using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "SO/DialogueData")]
public class DialogueData : ScriptableObject
{
    [field: SerializeField, TextArea(1,30)] public string[] Strings { get; private set; }
    [field: SerializeField] public int Index { get; private set; }
    [field: SerializeField] public HintQuality HintQuality { get; private set; }
}
