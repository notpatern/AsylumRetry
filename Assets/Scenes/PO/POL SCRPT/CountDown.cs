using UnityEngine;
using System;
using UnityEngine.Rendering;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] float time;
    [HideInInspector] public bool hasWon;
    TextMeshPro textmeshPro;
    [SerializeField] GameObject playerObject;
    PlayerController2DPlatformer player;


    void Awake()
    {
        textmeshPro = GetComponent<TextMeshPro>();
        player = playerObject.GetComponent<PlayerController2DPlatformer>();
        textmeshPro.text = time.ToString();
        hasWon = false;
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
    }

    public void StopOnDeath()
    {
        textmeshPro.fontSize = 9;
        textmeshPro.text = "You Lose! <br>Enter to retry <br>Esc to leave";
    }
}
