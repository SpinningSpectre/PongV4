using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float defaultBallMoveSpeed;
    public float moveSpeedIncrease;
    public float speedIncreaseOnWall;
    public float playerSpeed;
    public int winPoints;
    public int amountOfBalls;
    public GameObject[] balls;
    public GameObject mainBall;
    [Header("Default, Christmas, New years")]
    public Sprite[] ballIcons;
    public GameObject[] christmasBalls;
    public GameObject[] normalObjects;
    public GameObject[] christmasObjects;
    public GameObject[] newYearsObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeDefaultBallSpeed(string amount)
    {
        float number = float.Parse(amount);
        if (number < 2)
        {
            number = 2;
        }
        defaultBallMoveSpeed = number;
    }
    public void ChangeMoveSpeedIncreaseOnPeddal(string amount)
    {
        float number = float.Parse(amount);
        number = number + 1;
        if (number < 0)
        {
            number = 0f;
        }
        moveSpeedIncrease = number;
    }
    public void ChangeMoveSpeedIncreaseOnWall(string amount)
    {
        float number = float.Parse(amount);
        number = number + 1;
        if (number < 0)
        {
            number = 0f;
        }
        speedIncreaseOnWall = number;
    }
    public void ChangePlayerSpeed(string amount)
    {
        float number = float.Parse(amount);
        if (number < 1)
        {
            number = 1f;
        }
        playerSpeed = number;
    }
    public void ChangeWinRequirements(string amount)
    {
        int number = int.Parse(amount);
        if (number < 1)
        {
            number = 1;
        }
        winPoints = number;
    }
    public void ChangeBallAmount(string amount)
    {
        int number = int.Parse(amount);
        if (number < 1)
        {
            number = 1;
        }
        if (number > 10)
        {
            number = 10;
        }
        amountOfBalls = number;
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].SetActive(false);
            christmasBalls[i].SetActive(false);
        }
        for (int i = 0; i < amountOfBalls - 1; i++)
        {
            balls[i].SetActive(true);
            christmasBalls[i].SetActive(true);
        }
    }

    public void ChangeTheme(TMP_Dropdown theme)
    {
        TMP_Text text = theme.transform.GetChild(0).GetComponent<TMP_Text>();
        print(text.text);

        //Turns off every theme
        foreach (GameObject chris in christmasObjects)
        {
            chris.SetActive(false);
        }
        foreach (GameObject norm in normalObjects)
        {
            norm.SetActive(false);
        }
        foreach (GameObject newy in newYearsObjects)
        {
            newy.SetActive(false);
        }
        switch (text.text)
        {
            default:
                foreach (GameObject norm in normalObjects)
                {
                    norm.SetActive(true);
                }
                foreach (GameObject ball in balls)
                {
                    ball.GetComponent<SpriteRenderer>().sprite = ballIcons[0];
                }
                mainBall.GetComponent<SpriteRenderer>().sprite = ballIcons[0];
                    break;
            case "Christmas":
                foreach (GameObject chris in christmasObjects)
                {
                    chris.SetActive(true);
                    foreach (GameObject ball in balls)
                    {
                        ball.GetComponent<SpriteRenderer>().sprite = ballIcons[1];
                    }
                    mainBall.GetComponent<SpriteRenderer>().sprite = ballIcons[1];
                }
                break;
            case "New Years":
                foreach (GameObject newy in newYearsObjects)
                {
                    newy.SetActive(true);
                }
                foreach (GameObject ball in balls)
                {
                    ball.GetComponent<SpriteRenderer>().sprite = ballIcons[2];
                }
                mainBall.GetComponent<SpriteRenderer>().sprite = ballIcons[2];
                break;
        }
    }
}
