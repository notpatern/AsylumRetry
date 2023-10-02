using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WinnerCheck : MonoBehaviour
{
    public Transform cam;
    public Transform player;
    private int winnerCheck;

    void Start()
    {
        winnerCheck = 4;
    }

    void Update()
    {
        if(BoxTrigger.compteurBox == winnerCheck)
        {
            cam.transform.position = new Vector3(53.6f, 16.12f, -19.75f);

        }
    }
}
