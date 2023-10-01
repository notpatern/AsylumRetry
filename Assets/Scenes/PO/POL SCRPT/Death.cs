using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    GameObject[] pLife;
    GameObject[] pDeath;

    void Start()
    {
        pLife = GameObject.FindGameObjectsWithTag("pLife");
        pDeath = GameObject.FindGameObjectsWithTag("pDeath");

        pLife[0].gameObject.SetActive(true);
        pDeath[0].gameObject.SetActive(false);
    }

    public void DisplayDeath()
    {
        pLife[0].gameObject.SetActive(false);
        pDeath[0].gameObject.SetActive(true);
    }
}
