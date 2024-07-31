using UnityEngine;

public class Trigger : MonoBehaviour, IInteractable
{
    string objectName;
    public GameObject varr;

    void Awake()
    {
        objectName = gameObject.transform.name;
    }

    public void Interact()
    {
        Debug.Log(objectName + " has been clicked on.");
        
        // Get the mainLevelSystem component
        mainLevelSystem levelSystem = varr.GetComponent<mainLevelSystem>();
        
        // Check if the property exists and set it to false
        System.Reflection.PropertyInfo prop = typeof(mainLevelSystem).GetProperty(objectName);
        if (prop != null && prop.PropertyType == typeof(bool))
        {
            prop.SetValue(levelSystem, false);
        }
        else
        {
            Debug.LogWarning("Property " + objectName + " not found or not a boolean in mainLevelSystem.");
        }
    }
}