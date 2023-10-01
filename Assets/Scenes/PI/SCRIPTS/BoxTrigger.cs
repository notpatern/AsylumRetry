using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public static int compteurBox;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "box")
            compteurBox -= 1;
    }

}
