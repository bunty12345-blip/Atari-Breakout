using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // config parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed;
    [SerializeField] int scorePerBlock = 40;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoplayEnabled;

    // state variables
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(int bonus)
    {
        currentScore = currentScore + scorePerBlock + bonus;  //added bonus points for bonus +250 brick 
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoplayEnabled;
    }
    public void GameSpeedFast()  // for updating gamespeed when it hits fast block
    {
        StartCoroutine("EnableSpeedGame");
    }

    IEnumerator EnableSpeedGame()    // Coroutine for updating gamespeed when it hits fast block
    {
        gameSpeed = 1.2f;
        yield return new WaitForSeconds(5.0f);
        gameSpeed = 0.7f;
    }

    public void GameSpeedSlow()  // for updating gamespeed when it hits Slow block
    {
        StartCoroutine("EnableSlowGame");
    }

    IEnumerator EnableSlowGame()    // Coroutine for updating gamespeed when it hits Slow block
    {
        gameSpeed = 0.4f;
        yield return new WaitForSeconds(5.0f);
        gameSpeed = 0.7f;
    }
}
