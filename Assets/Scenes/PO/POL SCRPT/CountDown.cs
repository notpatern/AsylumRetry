using UnityEngine;
using System;
using UnityEngine.Rendering;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] float time;
    [HideInInspector] public bool hasWon;
    TextMeshPro textmeshPro;


    void Awake()
    {
        textmeshPro = GetComponent<TextMeshPro>();
        textmeshPro.text = time.ToString();
        hasWon = false;
    }
    
    void Update()
    {
        WinCondition();
        if (!hasWon)
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
}
