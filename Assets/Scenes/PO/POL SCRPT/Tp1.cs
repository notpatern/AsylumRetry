using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp1 : MonoBehaviour
{
    public Transform Player;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        Player.transform.position = new Vector3(-10f, Player.transform.position.y, Player.transform.position.z);
    }
}
