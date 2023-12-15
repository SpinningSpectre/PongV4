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
    [SerializeField] private GameObject[] scoreParticles;
    [SerializeField] private GameObject[] scoreParticleLocations;

    public void AddP1Score()
    {
        Player1Score++;
        p1Text.text = Player1Score.ToString();
        GameObject sc = Instantiate(scoreParticles[0], scoreParticleLocations[0].transform.position, scoreParticleLocations[0].transform.rotation);
        sc.transform.parent = GameObject.Find("Particles").transform;
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
        GameObject sc = Instantiate(scoreParticles[1], scoreParticleLocations[1].transform.position, scoreParticleLocations[1].transform.rotation);
        sc.transform.parent = GameObject.Find("Particles").transform;
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

    public void KillAllParticles()
    {
        Transform partic = GameObject.Find("Particles").GetComponent<Transform>();
        for(int i = 0;i < partic.childCount;i++)
        {
            Destroy(partic.GetChild(i).gameObject);
        }
    }
}
