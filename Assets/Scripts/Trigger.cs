using UnityEngine;

public class Trigger : MonoBehaviour, IInteractable
{
    private string objectName;
    private GameObject varr;

    void Awake()
    {
        objectName = gameObject.transform.name;
        varr = GameObject.Find("Roach");
    }

    public void Interact()
    {
        if (varr == null) return;
        
        mainLevelSystem levelSystem = varr.GetComponent<mainLevelSystem>();
        System.Reflection.PropertyInfo prop = typeof(mainLevelSystem).GetProperty(objectName);
        
        if (prop != null && prop.PropertyType == typeof(bool))
        {
            prop.SetValue(levelSystem, true);
        }
    }
}