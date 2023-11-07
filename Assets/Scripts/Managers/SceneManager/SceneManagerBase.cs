using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerBase : MonoBehaviour
{
    public string sceneName;
    public GameManager gameManager;
    public List<GameObject> openUI = new List<GameObject>();
    // Start is called before the first frame update

    public virtual SceneManagerBase ReturnType()
    {
        return this;
    }
    public void SetGameManager()
    {
        gameManager = GameManager.instance;
    }

    public void ObjectActiveChange(GameObject go)
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
