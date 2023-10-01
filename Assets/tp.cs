using UnityEngine;

public class tp : MonoBehaviour
{
    public Transform player;
    public Transform cam;
    public void OnCollisionEnter(Collision collision)
    {
        player.transform.position = new Vector3(-112f, 1f, 9.5f);
        cam.transform.position = new Vector3(-78f, 18f, -27.4f);


    }
}
