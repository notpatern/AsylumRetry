using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp1sasha : MonoBehaviour
{
    public Transform Player;
    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, 1f);
    }
}
