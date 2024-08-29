using UnityEngine;

public class DoorOpen : MonoBehaviour, IInteractable
{
    // Variables that can be set in the unity editor so the script is modular.
    public GameObject doorObject;
    public float angle;

    public void Interact()
    {
        // Check if a door object is assigned and if it is then set the angle to the angle variable and then print for debugging.
        if (doorObject != null)
        {
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            doorObject.transform.rotation = targetRotation;
            Debug.Log("Door Handle Used");
        }
    }
}