using TMPro;
using UnityEngine;

public class win : MonoBehaviour
{
    TextMeshPro textmeshPro;
 
    private void Start()
    {
        textmeshPro = GetComponent<TextMeshPro>();
        textmeshPro.text = " ";
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        textmeshPro.text = "You Win!";

    }

}
