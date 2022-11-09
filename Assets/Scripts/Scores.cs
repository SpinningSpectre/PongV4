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
    public int Player1win = 10;
    public int Player2win = 10;
    public int Player3win = 5;
    public int Player1spin = 2;
    public int Player2spin = 2;
    public Text p1Text;
    public Text p2Text;
    public Text p3Text;
    [SerializeField]
    GameObject Spinner;
    [SerializeField]
    Transform Tp1;
    [SerializeField]
    Transform Tp2;

    public void AddP1Score()
    {
        Player1Score++;
        p1Text.text = Player1Score.ToString();
        if (Player1Score == Player1win)
        {
            SceneManager.LoadScene("BlueWin");
        }
        if (Player1Score == Player1spin)
        {
            Instantiate(Spinner, Tp1.position, Tp1.rotation);
        }
    }
    public void AddP2Score()
    {
        Player2Score++;
        p2Text.text = Player2Score.ToString();
        if (Player2Score == Player2win)
        {
           SceneManager.LoadScene("RedWin");
        }
        if (Player2Score == Player2spin)
        {
            Instantiate(Spinner, Tp2.position, Tp2.rotation);
        }
    }
    public void AddP3Score()
    {
        Player3Score++;
        p3Text.text = Player3Score.ToString();
        if (Player3Score == Player3win)
        {
            SceneManager.LoadScene("YellowWin");
        }
    }
}
