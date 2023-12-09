using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Queue<string> sentences;

    // This variable checks if all the text of a given sentence has been displayed
    // This is to keep the "GetMouseButton" update in check and prevent it from advancing multiple lines at once.
    public bool textDisplayed = true;


    // Start is called before the first frame update
    void Awake()
    {
        sentences = new Queue<string>();
        Debug.Log("This should be first: " + sentences);
    }

    
    private void Update()
    {
        // If the player left-clicks and the text for the current text box has been displayed, advance the text.
        if (Input.GetMouseButtonDown(0) && textDisplayed)
        {
            Debug.Log("Click method should display next sentence");
            DisplayNextSentence();

        }

    }
    

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        Debug.Log(sentences);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        textDisplayed = false;

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        textDisplayed = true;
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.01f);
        }
    }
    void EndDialogue()
    {
        Debug.Log("Ending Conversation...");
    }

}
