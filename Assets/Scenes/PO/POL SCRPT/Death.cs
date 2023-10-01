using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Death : MonoBehaviour
{
    GameObject[] pLife;
    GameObject[] pDeath;

    void Start()
    {
        pLife = GameObject.FindGameObjectsWithTag("pLife");
        pDeath = GameObject.FindGameObjectsWithTag("pDeath");

        foreach (GameObject i in pLife)
        {
            i.gameObject.SetActive(true);
        }

        pDeath[0].gameObject.SetActive(false);
    }

    public void DisplayDeath()
    {
        
        pDeath[0].gameObject.SetActive(true);
        

        foreach (GameObject i in pLife)
        {
            i.gameObject.SetActive(false);
        }
    }
}
