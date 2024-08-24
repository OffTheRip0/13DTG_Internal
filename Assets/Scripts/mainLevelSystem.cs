using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainLevelSystem : MonoBehaviour
{   
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
        TimerOn1 = FindObjectOfType<Timer>();
    }

    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn1.TimerOn == false & LevelOver == false){
            Debug.Log("Timer Over");
            LevelOver = true;

            if (one & two & three & four){
                Debug.Log("Win.");
                Cursor.lockState = CursorLockMode.None;
                MenuCanvas.SetActive(true);
                WinMenu.SetActive(true);
            }
            else{
                Debug.Log("Lose.");
                Cursor.lockState = CursorLockMode.None;
                MenuCanvas.SetActive(true);
                LoseMenu.SetActive(true);
            }


        }
    }
}
