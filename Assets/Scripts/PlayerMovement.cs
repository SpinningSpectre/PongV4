using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerNumber = 1;
    public float playerSpeed = 4;

    // Update is called once per frame
    void Update()
    {
        if (playerNumber == 1)
        {
            transform.Translate(new Vector3(0, Input.GetAxis("Player1")* Time.deltaTime* playerSpeed, 0));
        }
        if (playerNumber == 2)
        {
            transform.Translate(new Vector3(0, Input.GetAxis("Player2")* Time.deltaTime* playerSpeed, 0));
        }
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3,3), transform.position.z);
    }
    public void UpdateStats()
    {
        Stats stat = FindObjectOfType<Stats>();
        playerSpeed = stat.playerSpeed;
    }
}
