using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxTrigger : MonoBehaviour
{
    public static int compteurBox = 3;
    public Transform cam;
    public Transform player;
    private bool levelOne;

    // Start is called before the first frame update
    void Start()
    {
        levelOne = true;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "box")
        {
            Debug.Log("Toby");
            compteurBox += 1;
        }
        
        if (compteurBox == 4)
        {
            if(levelOne)
            {
                cam.transform.position = new Vector3(53.6f, 16.12f, -19.75f);
                player.position = new Vector3(29.2999992f, 3.79999995f, 16.6119995f);
                compteurBox = 0;
                levelOne = false;
            }
            else
            {
                Debug.Log("Caca");
                compteurBox = 0;
                PlayerPrefs.SetInt("level3", 1);
                SceneManager.LoadScene("Corridor");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "box")
            compteurBox -= 1;
    }

}
