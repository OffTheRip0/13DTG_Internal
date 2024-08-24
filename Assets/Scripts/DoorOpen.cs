using UnityEngine;

public class DoorOpen : MonoBehaviour, IInteractable
{
    private string objectName;
    public GameObject doorObject;
    public float angle;



    public void Interact()
    {
        if (doorObject != null)
        {
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            doorObject.transform.rotation = targetRotation;
            Debug.Log("Door Handle Used");
        }
    }
}
