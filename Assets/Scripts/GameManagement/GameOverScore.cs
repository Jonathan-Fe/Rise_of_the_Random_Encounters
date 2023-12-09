using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Days Survived: " + (partyInformation.Instance.Days -1);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Title_Screen");
    }

}
