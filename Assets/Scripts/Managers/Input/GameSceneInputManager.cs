using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneInputManager : InputManagerBase
{

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
}
