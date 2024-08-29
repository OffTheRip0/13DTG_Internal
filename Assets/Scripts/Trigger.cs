using UnityEngine;

public class Trigger : MonoBehaviour, IInteractable
{
    private string objectName;
    private GameObject varr;
    public AudioSource source;
    public AudioClip clip;


    void Awake()
    {
        // When the script it loaded find the player object which is Roach and also get the name of the object the script is attached to.
        objectName = gameObject.transform.name;
        varr = GameObject.Find("Roach");
    }

    public void Interact()
    {
        // Check if Roach has been found
        if (varr == null) return;
        
        // Get the mainLevelSystem component from the varr object and find the variable with the name of the object
        mainLevelSystem levelSystem = varr.GetComponent<mainLevelSystem>();
        System.Reflection.PropertyInfo prop = typeof(mainLevelSystem).GetProperty(objectName);
        
        // Check if it is a boolean and if yes then set it to true, print a debug statement and play the found sound.
        if (prop != null && prop.PropertyType == typeof(bool))
        {
            prop.SetValue(levelSystem, true);
            Debug.Log(objectName + " found.");
            source.PlayOneShot(clip);
        }
    }
}