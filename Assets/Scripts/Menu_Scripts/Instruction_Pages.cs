using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Instruction_Pages : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;

    public Button page1Button;
    public Button page2Button;
    public Button page3Button;
    public Button page4Button;

    // Update is called once per frame
    void Update()
    {
        checkPage();
    }

    // check if page 1 is open
    // if it is, make the page 1 button non-interactable.
    public void checkPage()
    {
        if (Page1.activeSelf)
        {
            page1Button.interactable = false;
        } else
        {
            page1Button.interactable = true;
        }

        if (Page2.activeSelf)
        {
            page2Button.interactable = false;
        }
        else
        {
            page2Button.interactable = true;
        }

        if (Page3.activeSelf)
        {
            page3Button.interactable = false;
        }
        else
        {
            page3Button.interactable = true;
        }

        if (Page4.activeSelf)
        {
            page4Button.interactable = false;
        }
        else
        {
            page4Button.interactable = true;
        }
    }
}
