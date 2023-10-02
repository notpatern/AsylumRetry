using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject canvas;
    private bool GameIsPaused;


    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameIsPaused = true;
    }

    // Update is called once per frame
    public void Play()
    {
        Debug.Log("Play");
        canvas.gameObject.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Update()
    {
        Debug.Log(GameIsPaused.ToString());
        if (Input.GetKeyDown(KeyCode.Escape) & GameIsPaused == false)
        {
            Debug.Log("Caca");
            canvas.gameObject.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GameIsPaused)
        {
            Play();
        }
    }
}
