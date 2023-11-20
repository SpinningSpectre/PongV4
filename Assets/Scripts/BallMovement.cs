using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float moveSpeedIncrease = 1.1f;
    [SerializeField] float slightMoveSpeedIncrease = 1.01f;
    Vector2 ballDirection = new Vector2(1, 1);
    [SerializeField] float defaultMoveSpeed = 7;
    Scores score;
    [SerializeField] bool showsTimer;
    [SerializeField] Text timerText;
    [SerializeField] float timeUntilRespawn;
    [SerializeField] private float timeTillBallSpawn = 0;
    [SerializeField] private Stats stats;

    [SerializeField] private GameObject bounceParticle;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Scores>();
    }
    // Update is called once per frame
    void Update()
    {
        //Hope it aint broken
        if (transform.position.x > 20 || transform.position.x < -30)
        {
            SpawnBall();
        }
        timeTillBallSpawn -= Time.deltaTime;
        if(stats.amountOfBalls < 2)
        {
            if(timeTillBallSpawn > 2 && timeTillBallSpawn < 3)
            {
                timerText.text = "3";
                timerText.color = Color.red;
            }
            else if (timeTillBallSpawn > 1 && timeTillBallSpawn < 2)
            {
                timerText.text = "2";
                timerText.color = Color.yellow;
            }
            else if (timeTillBallSpawn > 0 && timeTillBallSpawn < 1)
            {
                timerText.text = "1";
                timerText.color = Color.white;
            }
        }
        if (timeTillBallSpawn < 0)
        {
            if (stats.amountOfBalls < 2)
            {
                timerText.text = "";
            }
            if (moveSpeed > 70)
            {
                moveSpeed = 70;
            }
            transform.Translate(ballDirection * moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5), transform.position.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            ballDirection = Vector3.Reflect(ballDirection, collision.contacts[0].normal);
            moveSpeed = moveSpeed * slightMoveSpeedIncrease;
            Instantiate(bounceParticle, gameObject.transform.position, gameObject.transform.rotation);
        }
        if (collision.gameObject.CompareTag("Paddle"))
        {
            ballDirection = Vector3.Reflect(ballDirection, collision.contacts[0].normal);
            moveSpeed = moveSpeed * moveSpeedIncrease;
            Instantiate(bounceParticle, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            SpawnBall();
            score.AddP1Score(); 
        }
        if (collision.gameObject.CompareTag("Barrier2"))
        {
            SpawnBall();
            score.AddP2Score();
        }
    }
    public void SpawnBall()
    {

        transform.position = new Vector3(0, 0, 0);
        for(int i =0; i < 10; i++)
        {
            ballDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            if (ballDirection.x > -0.2f && ballDirection.x < 0.2f)
            {
                i--;
                continue;
            }
            i = 10;
        }
        ballDirection = ballDirection.normalized;
        moveSpeed = defaultMoveSpeed;
        if(stats.amountOfBalls < 2)
        {
            timeTillBallSpawn = timeUntilRespawn;
        }
    }

    public void UpdateStats()
    {
        Stats stat = FindObjectOfType<Stats>();
        defaultMoveSpeed = stat.defaultBallMoveSpeed;
        moveSpeedIncrease = stat.moveSpeedIncrease;
        slightMoveSpeedIncrease = stat.speedIncreaseOnWall;
    }
}
