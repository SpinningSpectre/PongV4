using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    public int Player1Score = 0;
    public int Player2Score = 0;
    public int Player3Score = 0;
    public Text p1Text;
    public Text p2Text;
    public Text p3Text;

    public void AddP1Score()
    {
        Player1Score++;
        p1Text.text = Player1Score.ToString();
        if (Player1Score == 10)
        {
            SceneManager.LoadScene("BlueWin");
        }
    }
    public void AddP2Score()
    {
        Player2Score++;
        p2Text.text = Player2Score.ToString();
        if (Player2Score == 10)
        {
           SceneManager.LoadScene("RedWin");
        }
    }
    public void AddP3Score()
    {
        Player3Score++;
        p3Text.text = Player3Score.ToString();
        if (Player3Score == 5)
        {
            SceneManager.LoadScene("YellowWin");
        }
    }
}
