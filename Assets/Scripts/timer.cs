using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{

    
    public GameObject Lastrun;
    public TMPro.TextMeshProUGUI last_run;
    public GameObject score;
    public TMPro.TextMeshProUGUI score_text;
    public float timerr;
    //running functions when invoked from other script
    private void OnEnable()
    {
        //CollideCheck.OnPlayerCollision += ResetTimer;
        //finishGame.OnPlayerCollision2 += end_game;
    }
    //running functions when invoked from other scripts
    private void OnDisable()
    {
        //CollideCheck.OnPlayerCollision -= ResetTimer;
        //finishGame.OnPlayerCollision2 -= end_game;
    }
    //get components
    private void Start()
    {
        score_text = score.GetComponent<TMPro.TextMeshProUGUI>();
    }
    //updates the timer, rounds the number then displays it.
    public void Update()
    {
        timerr += Time.deltaTime;
        string formattedTime = timerr.ToString("0.00");
        score_text.text = formattedTime;
    }
    //resets timer
    private void ResetTimer()
    {
        timerr = 0f;
    }
    // ends game when the player touches the end capsule, logs their time and displays it on a last run component.
    public void end_game()
    {
        last_run = Lastrun.GetComponent<TMPro.TextMeshProUGUI>();
        string formattedTime = timerr.ToString("0.00");
        last_run.text = formattedTime;
        timerr = 0f;
    }
}
