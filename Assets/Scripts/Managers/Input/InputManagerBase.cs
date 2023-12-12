using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerBase : MonoBehaviour
{

    public GameManager gameManager;
    public SceneManagerBase sceneManager;

    protected virtual InputManagerBase ReturnType()
    {
        return this;
    }
    public virtual void AddEvent()
    {

    }
    protected virtual void SetInputManager()
    {
        gameManager.inputManager = ReturnType();
    }

    public  void GetESCKey()
    {
        //열려있는 UI중 가장 마지막에 열린 UI SetActiveFalse
        if (sceneManager == null)
            sceneManager = gameManager.sceneManager;
        if (Input.GetKeyUp(KeyCode.Escape)&&sceneManager.openUI.Count > 0)
        {
            sceneManager.openUI[sceneManager.openUI.Count - 1].SetActive(false);
            sceneManager.openUI.RemoveAt(sceneManager.openUI.Count - 1);
        }
    }

    public virtual void GetDirectionKey()
    {

    }
    
}
