using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;
    public bool gameOver;

    private void Awake()
    {
        if(intance == null)
        {
            intance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        UiManager.intance.GameStart();
        ScoreManager.intance.startScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatform();
    }

    public void GameOver()
    {
        UiManager.intance.GameOver();
        ScoreManager.intance.stopScore();
        gameOver = true;
    }

}
