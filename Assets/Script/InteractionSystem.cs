using UnityEngine;
using TMPro;

// Simple interaction system using a raycast from the camera.
public class InteractionSystem : MonoBehaviour
{
    public float interactionRange = 3f;
    public KeyCode interactionKey = KeyCode.E;
    public Camera playerCamera;

    [Header("UI")]
    public GameObject promptObject; // simple panel/text that shows when looking at object
    public TextMeshProUGUI promptText;

    private IInteractable currentInteractable;

    void Start()
    {
        if (playerCamera == null) playerCamera = Camera.main;
        if (promptObject != null) promptObject.SetActive(false);
    }

    void Update()
    {
        DetectInteractable();
        if (currentInteractable != null && Input.GetKeyDown(interactionKey))
            currentInteractable.Interact();
    }

    void DetectInteractable()
    {
        IInteractable newInteractable = null;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange))
        {
            // Try to get any MonoBehaviour on the hit and cast to IInteractable
            var mb = hit.collider.GetComponent<MonoBehaviour>();
            newInteractable = mb as IInteractable;
        }

        if (newInteractable != currentInteractable)
        {
            if (currentInteractable != null) currentInteractable.OnLookAway();
                
            currentInteractable = newInteractable;
            
                if (currentInteractable != null)
                {
                    currentInteractable.OnLookAt();
                    if (promptObject != null)
                    {
                        promptObject.SetActive(true);
                        if (promptText != null) promptText.text = currentInteractable.GetInteractionText();
                    }
                }
                else
                {
                    if (promptObject != null) promptObject.SetActive(false);
                }
        }
    }
}
