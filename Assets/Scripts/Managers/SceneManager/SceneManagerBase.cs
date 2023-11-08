using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerBase : MonoBehaviour
{
    public string sceneName;
    public GameManager gameManager;
    public InputManagerBase inputManager;
    public List<GameObject> openUI = new List<GameObject>();
    

    public virtual SceneManagerBase ReturnType()
    {
        return this;
    }
    public void SetGameManager()
    {
        gameManager = GameManager.instance;
    }
    public virtual void SetInputManager()
    {
        
    }
    protected virtual void SetSceneManager()
    {
        gameManager.sceneManager = this;
    }
    public void ChangeUIActive(GameObject go)
    {
        if (go.activeSelf)
        {
            go.SetActive(false);
            Debug.Log(go.name);
            openUI.Remove(go);
        }
        else if (!go.activeSelf)
        {
            go.SetActive(true);
            openUI.Add(go);
        }
    }
}
