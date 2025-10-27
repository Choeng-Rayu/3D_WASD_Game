using UnityEngine;
using TMPro;

// Simple clue object: shows text on a UI when interacted
public class ClueObject : InteractableObject
{
    public string clueTitle = "Clue Found!";
    [TextArea] public string clueDescription = "This is a clue...";
    public TextMeshProUGUI clueDisplayUI;

    protected override void OnObjectInteracted()
    {
        if (clueDisplayUI != null)
        {
            clueDisplayUI.text = $"<b>{clueTitle}</b>\n\n{clueDescription}";
            clueDisplayUI.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log($"Clue: {clueTitle} - {clueDescription}");
        }
    }
}
