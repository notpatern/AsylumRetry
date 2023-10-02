using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerProg : MonoBehaviour
{
    GameObject[] l2;
    GameObject[] l3;
    GameObject[] l4;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Level1"))
        {
            PlayerPrefs.SetInt("Level1", 0);
        }

        if (!PlayerPrefs.HasKey("Level2"))
        {
            PlayerPrefs.SetInt("Level2", 0);
        }

        if (!PlayerPrefs.HasKey("Level3"))
        {
            PlayerPrefs.SetInt("Level3", 0);
        }

        if (!PlayerPrefs.HasKey("Level4"))
        {
            PlayerPrefs.SetInt("Level4", 0);
        }

        if (!PlayerPrefs.HasKey("Sensitivity"))
        {
            PlayerPrefs.SetFloat("Sensitivity", 5f);
        }
    }

    private void Start()
    {
        l2 = GameObject.FindGameObjectsWithTag("L2");
        l3 = GameObject.FindGameObjectsWithTag("L3");
        l4 = GameObject.FindGameObjectsWithTag("L4");
    }

    private void Update()
    {
        FrameManager();
    }

    private void FrameManager ()
    {
        if (PlayerPrefs.GetInt("Level1") == 1)
        {
            foreach (GameObject i in l2)
            {
                i.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject i in l2)
            {
                i.gameObject.SetActive(false);
            }
        }

        if (PlayerPrefs.GetInt("Level2") == 1)
        {
            foreach (GameObject i in l3)
            {
                i.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject i in l3)
            {
                i.gameObject.SetActive(false);
            }
        }

        if (PlayerPrefs.GetInt("Level3") == 1)
        {
            foreach (GameObject i in l4)
            {
                i.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject i in l4)
            {
                i.gameObject.SetActive(false);
            }
        }
    }
}
