using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Scores : MonoBehaviour
{
    [SerializeField] int Player1Score = 0;
    [SerializeField] int Player2Score = 0;
    [SerializeField] int Player1win = 10;
    [SerializeField] int Player2win = 10;
    [SerializeField] Text p1Text;
    [SerializeField] Text p2Text;
    [SerializeField] UnityEvent endingEvent;
    [SerializeField] GameObject blueWin;
    [SerializeField] GameObject redWin;

    public void AddP1Score()
    {
        Player1Score++;
        p1Text.text = Player1Score.ToString();
        if (Player1Score == Player1win)
        {
            endingEvent.Invoke();
            ResetScores();
            blueWin.SetActive(true);
        }
    }
    public void AddP2Score()
    {
        Player2Score++;
        p2Text.text = Player2Score.ToString();
        if (Player2Score == Player2win)
        {
            endingEvent.Invoke();
            ResetScores();
            redWin.SetActive(true);
        }
    }
    public void ResetScores()
    {
        Player1Score = 0;
        Player2Score = 0;
        p1Text.text = Player1Score.ToString();
        p2Text.text = Player2Score.ToString();
    }
    public void UpdateStats()
    {
        Stats stat = FindObjectOfType<Stats>();
        Player1win = stat.winPoints;
        Player2win = stat.winPoints;
    }
}
