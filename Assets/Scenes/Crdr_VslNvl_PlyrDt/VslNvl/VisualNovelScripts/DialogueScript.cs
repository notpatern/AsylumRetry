using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueScript : MonoBehaviour
{
    List<string> dialogueLines;

    public static int dialogueIndex;
    [SerializeField] TextMeshPro text;

    [SerializeField] Transform cam;
    [SerializeField] Transform textPosition;


    private void Start()
    {
        dialogueLines = new List<string>
        {
            "...",
            "<i>???</i>",
            "It is time",
            "<i>Who are you?</i>",
            "...",
            "<i>You’re here for me aren’t you?</i>",
            "I am.",
            "<i>Can’t I just stay here?</i>",
            "Unfortunately no.",
            "The choice is not yours, it never was.",
            "<i>...</i>",
            "Your life here was but everlasting.",
            "None of the memories you’ve made will change the way things were but they have changed the way things are.",
            "<i>But I don’t want to go back.</i>",
            "<i>I don’t want to face it again.</i>",
            "<i>The weight of the world.</i>",
            "<i>The light of their words</i>",
            "<i>I don’t want any of that to hurt me again.</i>",
            "Your time in this place comes to an end as the time of pain and secrecy is over.",
            "None of you shall hide anymore as you are now one with yourselves.",
            "Ask your mirror for the time and it shall answer one last time.",
            "Then we’ll go.",
            "<i>Alright.</i>",
            "*The protagonist opens their eyes and sees themselves in small living room*",
            "*As they approach the mirror, a rumble makes itself louder and louder*",
            "*The mirror then speaks his wise words*",
            "*As the keeper of time, it shall share its power and let the protagonist take a glimpse at the flow of time*",
            "*IT*",
            "*IS*",
            "*MUFFIN*",
            "*TIME*",
        };
        dialogueIndex = 0;
        text.text = string.Empty;
    }

    void Update()
    {
        Debug.Log(dialogueIndex.ToString());
        IncrementIndex();
        DisplayText();
        SceneryChanges();
    }

    private void DisplayText()
    {
        text.text = dialogueLines[dialogueIndex];
    }

    private void IncrementIndex()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !(dialogueIndex + 1 == dialogueLines.Count))
        {
            dialogueIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && (dialogueIndex + 1 == dialogueLines.Count))
        {
            PlayerPrefs.SetInt("Level4", 1);
            SceneManager.LoadScene("WhiteRoom");
        }
    }

    private void SceneryChanges()
    {
        if (dialogueLines[dialogueIndex][0] == '<')
        {
            cam.position = new Vector3(108.2945f, 1f, -10f);
            textPosition.position = new Vector3(107f, 0f, 82.2f);
        }
      

        else if (dialogueLines[dialogueIndex][0] == '*')
        {
            cam.position = new Vector3(218.114493f, 1f, -10f);
            textPosition.position = new Vector3(217, 0f, 82.2f);
        }
    

        else
        {
            cam.position = new Vector3(0f, 1f, -10f);
            textPosition.position = new Vector3(-1.3f, 0f, 82.2f);
        }
 
    }
}
