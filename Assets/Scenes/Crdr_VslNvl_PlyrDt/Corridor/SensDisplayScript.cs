using System;
using TMPro;
using UnityEngine;

public class SensDisplayScript : MonoBehaviour
{
    public TMP_Text textmeshPro;

    private void Update()
    {
        textmeshPro.text = Math.Round(PlayerPrefs.GetFloat("Sensitivity"), 3).ToString();
    }

}
