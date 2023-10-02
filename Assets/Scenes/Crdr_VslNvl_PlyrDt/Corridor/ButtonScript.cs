using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject canva;
    public static bool Paused;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Level4") == 1)
            Resume();
     
        if (PlayerPrefs.GetInt("Level4") != 1)
            Pause();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        canva.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        canva.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        float sens = PlayerPrefs.GetFloat("Sensitivity");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("Sensitivity", sens);
    }
}
