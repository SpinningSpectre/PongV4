using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float MoveSpeed;
    Vector2 BallDirection = new Vector2(1, 1);
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //Hope it aint broken
        transform.Translate(BallDirection * MoveSpeed * Time.deltaTime);
    }
}
