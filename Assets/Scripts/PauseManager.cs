using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] KeyCode pauseKey;
    [SerializeField] GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    } 
}
