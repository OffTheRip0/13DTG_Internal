using UnityEngine;

public class Trigger : MonoBehaviour, IInteractable
{
    private string objectName;
    private GameObject varr;
    public AudioSource source;
    public AudioClip clip;


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
            Debug.Log(objectName + " found.");
            source.PlayOneShot(clip);
        }
    }
}