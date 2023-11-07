using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneInputManager : InputManagerBase
{


    public override InputManagerBase ReturnType()
    {
        return this;
    }
    public override void SetInputManager()
    {
        if (gameManager == null)
            gameManager = GameManager.instance;
        gameManager.inputManager = ReturnType();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetInputManager();
    }

    // Update is called once per frame
    void Update()
    {
        GetESCKey();
    }

}
