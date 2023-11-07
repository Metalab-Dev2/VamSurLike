using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerBase : MonoBehaviour
{

    public GameManager gameManager;
    public SceneManagerBase sceneManager;

    public virtual InputManagerBase ReturnType()
    {
        return this;
    }

    public virtual void SetInputManager()
    {
        gameManager.inputManager = ReturnType();
    }

    public  void GetESCKey()
    {
        //�����ִ� UI�� ���� �������� ���� UI SetActiveFalse
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
