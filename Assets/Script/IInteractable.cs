using UnityEngine;

// Simple interface for interactive objects
public interface IInteractable
{
    void Interact();
    string GetInteractionText();
    void OnLookAt();
    void OnLookAway();
}
