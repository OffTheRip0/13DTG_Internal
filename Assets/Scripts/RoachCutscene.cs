using UnityEngine;
using UnityEngine.SceneManagement;

public class RoachCutscene : MonoBehaviour
{
    // Speed of the roach and timer variables.
    public float speed = 1f;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        // This moves the Roach object left for the cutscene.
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        // TImer running.
        timer += Time.deltaTime;
        // After the timer has run for 7 secs it will load the next scene which is the menu.
        if (timer >= 7f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
