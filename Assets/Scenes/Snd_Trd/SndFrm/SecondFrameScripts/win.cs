using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    TextMeshPro textmeshPro;
    float time; 
    bool g;
    private void Start()
    {
        textmeshPro = GetComponent<TextMeshPro>();
        textmeshPro.text = " ";
        g = false;
        time = 3f;
    }
    private void Update()
    {
        if (g)
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
            }
            if (time < 0)
            {
                PlayerPrefs.SetInt("Level2", 1);
                SceneManager.LoadScene("Corridor");
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        textmeshPro.text = "You Win!";
        g = true;
    }

}
