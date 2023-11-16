using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneInputManager : InputManagerBase
{
    float moveX;
    float moveY;
    public Vector2 moveTo;
    public GameObject player;
    PlayerState playerState;
    protected override InputManagerBase ReturnType()
    {
        return this;
    }
    protected override void SetInputManager()
    {
        if (gameManager == null)
            gameManager = GameManager.instance;
        gameManager.inputManager = ReturnType();
        Debug.Log("InputManager");
    }
    void Start()
    {
        SetInputManager();
        
    }
    void Update()
    {
        
    }
    void MoveTo()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        moveTo.x = moveX;
        moveTo.y = moveY;
        player.transform.Translate(moveTo.normalized*playerState.moveSpeed);
        playerState.front = moveTo;
    }
}
