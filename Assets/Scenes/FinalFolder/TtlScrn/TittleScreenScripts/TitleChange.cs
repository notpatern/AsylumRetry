using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleChange : MonoBehaviour
{
    public TMP_Text title;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Level4") == 0)
            title.text = "MUSEUM";
        else if (PlayerPrefs.GetInt("Level4") == 1)
            title.text = "ASYLUM";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
