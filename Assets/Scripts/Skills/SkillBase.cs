using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    public string skillName;
    protected GameObject playerObj;
    protected PlayerState playerState;
    protected Vector2 front;
    public void AddEvent()
    {
        Debug.Log("Todo!");
    }
    public virtual void SkillInitialize()
    {
        Debug.Log("SetSkillData");
    }
    public void SkillActive()
    {
        Debug.Log("To do SkillAvtive");
    }
    virtual public void SetSkill()
    {
        Debug.Log("Todo SetSkill");
    }
    virtual public void SetPlayerObject()
    {
        playerObj = GameObject.FindWithTag("Player");
        playerState = playerObj.transform.GetComponent<PlayerState>();
    }
    public void UpdateMonsterHitData(MonsterState monster)
    {
        if (!monster.damagedTime.ContainsKey(this))
        {
            monster.damagedTime.Add(this, Time.time);
        }
        else
        {
            monster.damagedTime[this] = Time.time;
        }
    }
    public void SetFront()
    {
        front = playerState.front;
    }
    virtual public void SetSkillObject()
    {
       
    }
}
