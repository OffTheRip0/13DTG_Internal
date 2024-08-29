using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for objects that can be interacted with
public interface IInteractable
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;

    void Start()
    {
        // Nothing happens are start.
    }

    void Update()
    {
        // Check for interaction input (E key)
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Create a ray from the interactor source
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            
            // Perform raycast to detect interactable objects and if it hits then run the Interact function on that object thats been hit.
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}