using UnityEngine;
using System;
using UnityEngine.Rendering;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float time;
    TextMeshPro textmeshPro;


    void Awake()
    {
        textmeshPro = GetComponent<TextMeshPro>();
        textmeshPro.text = time.ToString();
    }
    void Start()
    {
        time = 60f;
    }

    
    void Update()
    {
        time -= Time.deltaTime;
        textmeshPro.text = Math.Round(time).ToString();
        if (time < 0)
        {
            time = 60;
        }
    }
}
