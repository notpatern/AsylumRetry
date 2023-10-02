using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncrScript : MonoBehaviour
{
    public TMP_Text compteur;

    void Update()
    {
        compteur.text = BoxTrigger.compteurBox.ToString();
    }
}
