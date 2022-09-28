using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public int Player1Score = 0;
    public int Player2Score = 0;
    public Text p1Text;
    public Text p2Text;

    public void AddP1Score()
    {
        Player1Score++;
        p1Text.text = Player1Score.ToString();
        if (Player1Score == 1) ;
        {
            //            GameObject.Find("OhHeyAWinB").GetComponent<Bl>().BlueWins();
        }
    }
    public void AddP2Score()
    {
        Player2Score++;
        p2Text.text = Player2Score.ToString();
        if (Player2Score == 1)
        {
            use SceneManager,;LoadScene(BlueWin);
        }
    }
}
