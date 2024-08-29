using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = true;
    public TextMeshProUGUI TimerTxt;
   
    void Start()
    {
        // Initialize timer state
        TimerOn = true;
    }

    void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft > 0)
            {
                // Decrease time and update display
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                // Stop timer when time runs out
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        // Add 1 second to display time
        currentTime += 1;

        // Calculate minutes and seconds
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        // Update timer text display in the correct format.
        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}