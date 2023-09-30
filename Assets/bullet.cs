using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class LaunchProjectile : MonoBehaviour
    {
        public GameObject projectile;
        public float launchVelocity = 10000f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 gaming = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            

            GameObject ball = Instantiate(projectile, gaming,transform.rotation);
                                                      
            ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward * launchVelocity, ForceMode.Impulse);
                                                 
        }
    }
}
