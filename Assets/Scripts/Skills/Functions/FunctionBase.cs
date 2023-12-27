using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionBase : MonoBehaviour
{
    string functionName;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        AddDictionary();
    }

    protected void AddDictionary()
    {
        functionName = this.GetType().Name;
        if (functionName == "FunctionBase")
        {
            return;
        }
        else
        {
            DataManager.instance.functions.Add(functionName, this);
        }
        Debug.Log("To do // Fuction Test");
        Debug.Log(functionName);
    }

    public virtual void AddFunction(ActiveSkills skill, float change)
    {

    }
    public virtual void MultiplFunction(ActiveSkills skill, float change)
    {

    }
}
