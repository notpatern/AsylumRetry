using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

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

    public void MoveTexture(Vector2 position)
    {
        transform.position = new Vector3(position.x, transform.position.y, position.y);
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
