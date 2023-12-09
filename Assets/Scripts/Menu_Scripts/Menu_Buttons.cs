using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Buttons : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;

    public void startButton()
    {
        SceneManager.LoadScene("Intro_Cutscene");
    }

    public void instructionButton()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void quitButton()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Title_Screen");
    }

    
    public void openPage1()
    {
        Page1.SetActive(true);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(false);
    }

    public void openPage2()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
        Page3.SetActive(false);
        Page4.SetActive(false);
    }

    public void openPage3()
    {
        Page1.SetActive(false);
        Page2.SetActive(false);
        Page3.SetActive(true);
        Page4.SetActive(false);
    }

    public void openPage4()
    {
        Page1.SetActive(false);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(true);
    }
}
