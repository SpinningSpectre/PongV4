using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    public BallMovement[] balls;
    public Stats stat;
    // Start is called before the first frame update
    void Start()
    {
        stat = FindObjectOfType<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateStats()
    {
        for(int i = 0; i < balls.Length; i++)
        {
            balls[i].UpdateStats();
        }
    }
    public void ResetBalls()
    {
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].SpawnBall();
        }
    }
}
