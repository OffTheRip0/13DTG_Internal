using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainLevelSystem : MonoBehaviour
{   
    public bool LevelOver = false;
    public Timer TimerOn1;
    
    public bool ak47 { get; set; } = false;
    public bool laptop { get; set; } = false;
    public bool cash { get; set; } = false;
    public bool body { get; set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        TimerOn1 = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn1.TimerOn == false & LevelOver == false){
            Debug.Log("Timer Over");
            LevelOver = true;

            if (ak47 & laptop & cash & body){
                Debug.Log("Win.");
            }
            else{
                Debug.Log("Lose.");
            }


        }
    }
}
