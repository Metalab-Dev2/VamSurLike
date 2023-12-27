using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerProvider
{
    GameObject player { get; set; }
}


public class GameSceneInputManager : InputManagerBase,IPlayerProvider
{
    [SerializeField]float moveX;
    [SerializeField]float moveY;
    public Vector2 moveTo = Vector2.zero;
    public GameObject player { get; set; }
    PlayerState playerState;
    
    protected override InputManagerBase ReturnType()
    {
        return this;
    }
    
    public override void AddEvent()
    {
        SetInputManager();
    }

    protected override void SetInputManager()
    {
        if (gameManager == null)
            gameManager = GameManager.instance;
        gameManager.inputManager = ReturnType();
        Debug.Log("InputManager");
    }

    public void MoveTo()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        moveTo.x = moveX;
        moveTo.y = moveY;
        if (playerState == null)
        {
            playerState = player.transform.GetComponent<PlayerState>();
        }
        if (player != null)
        {
            player.transform.Translate(moveTo.normalized * playerState.moveSpeed * Time.deltaTime);
            playerState.front = moveTo;
        }
        
    }
}
