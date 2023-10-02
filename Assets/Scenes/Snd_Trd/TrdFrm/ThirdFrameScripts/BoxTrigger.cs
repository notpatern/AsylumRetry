using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxTrigger : MonoBehaviour
{
    public static int compteurBox;
    public Transform cam;
    public Transform player;
    public Transform trigger;
    private int lvlCheck;

    void Start()
    {
        lvlCheck = 0;
        compteurBox = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "box")
        {
            compteurBox += 1;
        }
        
        if (compteurBox == 4)
        {
            MoveObjects();
            lvlCheck += 1;
        }
    }

    private void Update()
    {
        if (lvlCheck == 2)
        {
            LoadNewScene();
        }
    }

    private void MoveObjects()
    {
        cam.transform.position = new Vector3(53.6f, 16.12f, -19.75f);
        player.position = new Vector3(29.2999992f, 3.79999995f, 16.6119995f);
        trigger.position = new Vector3(63.57f, 2.4f, 16.4f);
    }

    private void LoadNewScene()
    {
        PlayerPrefs.SetInt("level3", 1);
        SceneManager.LoadScene("Corridor");
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "box")
            compteurBox -= 1;
    }

}
