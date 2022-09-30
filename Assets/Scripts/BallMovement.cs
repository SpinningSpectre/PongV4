using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float MoveSpeed = 4f;
    private float MoveSpeedIncrease = 1.1f;
    private float SlightMoveSpeedIncrease = 1.01f;
    Vector2 BallDirection = new Vector2(1, 1);
    private float DefaultMoveSpeed = 7;
    // Start is called before the first frame update
    void Start()
    {
        BallDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        if (BallDirection.x >-0.2f && BallDirection.x <0.2f)
        {
            BallDirection = new Vector2(0.5f, BallDirection.y);
        }
        BallDirection = BallDirection.normalized;
    }
    // Update is called once per frame
    void Update()
    {
        //Hope it aint broken
        transform.Translate(BallDirection * MoveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            BallDirection = Vector3.Reflect(BallDirection, collision.contacts[0].normal);
            MoveSpeed = MoveSpeed * SlightMoveSpeedIncrease;
        }
        if (collision.gameObject.CompareTag("Paddle"))
        {
            BallDirection = Vector3.Reflect(BallDirection, collision.contacts[0].normal);
            MoveSpeed = MoveSpeed * MoveSpeedIncrease;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            ResetBall();
            GameObject.Find("Canvas").GetComponent<Scores>().AddP1Score(); 
        }
        if (collision.gameObject.CompareTag("Barrier2"))
        {
            ResetBall();
            GameObject.Find("Canvas").GetComponent<Scores>().AddP2Score();
        }
        if (collision.gameObject.CompareTag("BrokenBarrier"))
        {
            ResetBall();
            GameObject.Find("Canvas").GetComponent<Scores>().AddP3Score();
        }
    }
    private void ResetBall()
    {
        transform.position = new Vector3(0, 0, 0);
        BallDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        if (BallDirection.x > -0.2f && BallDirection.x < 0.2f)
        {
            BallDirection = new Vector2(0.5f, BallDirection.y);
        }
        BallDirection = BallDirection.normalized;
        MoveSpeed = DefaultMoveSpeed;
    }
}
