using UnityEngine;

public class Trigger : MonoBehaviour, IInteractable
    {
    string objectName;
    void Awake()
    {
        objectName = gameObject.transform.name;
    }
    public void Interact()
    {
        Debug.Log(objectName + " has been clicked on.");
    }
        
    }
