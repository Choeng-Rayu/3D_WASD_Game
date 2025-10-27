using UnityEngine;

// Basic base class for interactive objects
public class InteractableObject : MonoBehaviour, IInteractable
{
    [Header("Object")]
    public string objectName = "Object";
    [TextArea]
    public string interactionText = "Press E to interact";
    public bool singleUse = false;

    private Renderer objectRenderer;
    private Color originalColor;
    private bool hasInteracted = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
            originalColor = objectRenderer.material.color;
    }

    public void Interact()
    {
        if (singleUse && hasInteracted) return;
        hasInteracted = true;
        OnObjectInteracted();
    }

    public string GetInteractionText()
    {
        return interactionText;
    }

    public void OnLookAt()
    {
        if (objectRenderer != null)
            objectRenderer.material.color = originalColor * 1.2f;
    }

    public void OnLookAway()
    {
        if (objectRenderer != null)
            objectRenderer.material.color = originalColor;
    }

    // Override this in derived classes to implement behavior
    protected virtual void OnObjectInteracted() { }
}
