using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstlevelWinCondition : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform cam;

    private void Update()
    {
        WinCondition();
    }
    private void WinCondition()
    {
        if (BoxTrigger.compteurBox == 4)
        {
            player.position = new Vector3(34.8f, 37.4f, 17.25f);
            cam.position = new Vector3(53.6f, 16.1f, -19.75f);
        }
    }
}
