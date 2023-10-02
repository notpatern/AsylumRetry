using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    [SerializeField] float time;
    [HideInInspector] public bool hasWon;
    TextMeshPro textmeshPro;
    [SerializeField] GameObject playerObject;
    PlayerController2DPlatformer player;
    float i;


    void Awake()
    {
        textmeshPro = GetComponent<TextMeshPro>();
        player = playerObject.GetComponent<PlayerController2DPlatformer>();
        textmeshPro.text = time.ToString();
        hasWon = false;
    }

    private void Start()
    {
        i = 0;
    }

    void Update()
    {
        WinCondition();
        if (!hasWon && !player.died)
        {
            CoundDown();
        }
        if (hasWon)
        {
            DisplayWin();
        }
    }

    private void WinCondition()
    {
        if (time < 0)
        {
            hasWon = true;
            PlayerPrefs.SetInt("Level1", 1);
        }
    }

    private void CoundDown()
    {
        time -= Time.deltaTime;
        textmeshPro.fontSize = 36;
        textmeshPro.text = Math.Round(time).ToString();
    }

    private void DisplayWin()
    {
        time += Time.deltaTime;
        i += Time.deltaTime;
        textmeshPro.fontSize = 12;
        if (time > 1)
        {
            textmeshPro.text = "You Win!";
            if (time > 2) time = 0;
        }
        else if (time < 1)
        {
            textmeshPro.text = " ";
        }
        if (i > 6) { SceneManager.LoadScene("Corridor"); }
    }

    public void StopOnDeath()
    {
        textmeshPro.fontSize = 9;
        textmeshPro.text = "You Lose! <br>Enter to retry <br>Esc to leave";
    }
}
