using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mainLevelSystem : MonoBehaviour
{   
    public bool LevelOver = false;
    public Timer TimerOn1;
    public bool ak47 = false;
    public bool laptop = false;
    public bool cash = false;
    public bool body = false;
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

        }
    }
}
