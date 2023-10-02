using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp2: MonoBehaviour
{
    public Transform Player;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("fimskdfjms");
        Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, 58f);
    }
}
