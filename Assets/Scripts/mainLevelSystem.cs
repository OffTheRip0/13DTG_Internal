using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainLevelSystem : MonoBehaviour
{   
    // All variables and objects are set up.
    public bool LevelOver = false;
    public Timer TimerOn1;
    public GameObject MenuCanvas;
    public GameObject LoseMenu;
    public GameObject WinMenu;
    public bool one { get; set; } = false;
    public bool two { get; set; } = false;
    public bool three { get; set; } = false;
    public bool four { get; set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        // Find the timer.
        TimerOn1 = FindObjectOfType<Timer>();
    }

    public void RestartLevel()
    {
        // This function will reload the current scene.
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void NextLevel()
    {
        // This function will load the next scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        // If all the objects are found then unlock the cursor, Set the menu and win canvas to active and unlock the users cursor.
        if (one & two & three & four){
            Debug.Log("Win.");
            Cursor.lockState = CursorLockMode.None;
            MenuCanvas.SetActive(true);
            WinMenu.SetActive(true);
        }
        // If the time runs out and they have won then do the same as above
        if (TimerOn1.TimerOn == false & LevelOver == false){
            Debug.Log("Timer Over");
            LevelOver = true;

            if (one & two & three & four){
                Debug.Log("Win.");
                Cursor.lockState = CursorLockMode.None;
                MenuCanvas.SetActive(true);
                WinMenu.SetActive(true);
            }
            // If all the objects are not found and the time runs out then Set the menu nad lose canvas to active and also unlock the users cursor.
            else{
                Debug.Log("Lose.");
                Cursor.lockState = CursorLockMode.None;
                MenuCanvas.SetActive(true);
                LoseMenu.SetActive(true);
            }


        }
    }
}
