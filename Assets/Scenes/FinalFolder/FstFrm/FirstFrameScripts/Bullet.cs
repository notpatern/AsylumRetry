using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;

    public void Fire()
    {
        Vector3 gaming = new Vector3(transform.position.x, transform.position.y, transform.position.z);


        GameObject ball = Instantiate(projectile, gaming, transform.rotation);

        ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward * launchVelocity, ForceMode.Impulse);
    }
}
