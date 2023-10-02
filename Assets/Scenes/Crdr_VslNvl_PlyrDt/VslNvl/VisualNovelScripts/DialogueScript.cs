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

    private void Start()
    {
        dialogueLines = new List<string>
        {
            "Void: <br>*rumble*",
            "Protagonist: <br>???",
            "Void: <br>it is time",
            "Protagonist: <br>Who are you?",
            "Void: <br>*rumbles*",
            "Protagonist: <br>You’re here for me aren’t you?",
            "Void: <br>I am.",
            "Protagonist: <br>Can’t I just stay here?",
            "Void: <br>Unfortunately no.",
            "Void: <br>The choice is not yours, it never was.",
            "Protagonist: <br>Oh ok.",
            "Void: <br>Your life here was but everlasting.",
            "Void: <br>None of the memories you’ve made will change the way things were but they have changed the way things are.",
            "Protagonist: <br>But I don’t want to go back.",
            "Protagonist: <br>I don’t want to face it again.",
            "Protagonist: <br>The weight of the world.",
            "Protagonist: <br>The light of their words",
            "Protagonist: <br>I don’t want any of that to hurt me again.",
            "Void: <br>Your time in this place comes to an end as the time of pain and secrecy is over.",
            "Void: <br>None of you shall hide anymore as you are now one with yourselves.",
            "Void: <br>Ask your mirror for the time and it shall answer one last time.",
            "Void: <br>Then we’ll go.",
            "Protagonist: <br>Alright.",
            "*the protagonist opens their eyes and sees themselves in small living room*",
            "*as they approach the mirror, a rumble makes itself louder and louder*",
            "*the mirror then speaks his wise words*",
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
            SceneManager.LoadScene("WhiteRoom");
        }
    }
}
