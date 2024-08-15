using UnityEngine;
using UnityEngine.SceneManagement;

public class RoachCutscene : MonoBehaviour
{
    public float speed = 1f;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= 7f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
