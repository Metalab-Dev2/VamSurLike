using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : FunctionBase
{
    public override void AddFunction(ActiveSkills skill, float change)
    {
        if((skill.attackRange +change) >= 0.5)
        {
            skill.attackRange += change;
        }
        else
        {
            Debug.Log("AttackRange Can not be less than 0.5f");
            skill.attackCycle = 0.5f;
        }
        
    }
    public override void MultiplFunction(ActiveSkills skill, float change)
    {
        if(skill.attackRange *(1 + change) >= 0.5)
        {
            skill.attackRange *= (1 + change);
        }
        else
        {
            Debug.Log("AttackRange Can not be less than 0.5f");
            skill.attackRange = 0.5f;
        }
    }
}
