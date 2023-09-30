using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp2 : MonoBehaviour
{
    public Transform Player;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("fimskdfjms");
        Player.transform.position = new Vector3(45f, Player.transform.position.y, Player.transform.position.z);
    }
}
