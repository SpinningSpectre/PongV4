using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float defaultBallMoveSpeed;
    public float moveSpeedIncrease;
    public float speedIncreaseOnWall;
    public float playerSpeed;
    public int winPoints;
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
}
