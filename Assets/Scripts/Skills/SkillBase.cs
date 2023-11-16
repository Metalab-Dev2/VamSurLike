using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{

    protected GameObject playerObj;
    protected PlayerState playerState;
    protected Vector2 front;
    public void AddEvent()
    {
        playerState.OnInputSpace.AddListener(SkillActive);
    }
    public void SkillActive()
    {

    }
    private void Start()
    {
        
    }
    virtual public void SetSkill()
    {

    }
    virtual public void SetPlayerObject()
    {
        playerObj = GameObject.FindWithTag("Player");
        playerState = playerObj.transform.GetComponent<PlayerState>();
    }
    public void SetFront()
    {
        front = playerState.front;
    }
    virtual public void SetSkillObject()
    {
       
    }
}
