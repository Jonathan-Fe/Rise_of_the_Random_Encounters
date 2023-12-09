using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Cutscene_Dialogue : MonoBehaviour
{

    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
