using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //configuration parameters 
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    // cached references
    Ball theBall;
    GameStatus theGameStatus;

    // Start is called before the first frame update
    void Start()
    {
        theBall = FindObjectOfType<Ball>();
        theGameStatus = FindObjectOfType<GameStatus>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 paddlePos = new Vector2(GetXPos(), transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (theGameStatus.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
