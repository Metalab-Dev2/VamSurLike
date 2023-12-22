using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNumbers : FunctionBase
{
    public override void AddFunction(ActiveSkills skill, float change)
    {
        if (skill.ObjectNumber > 0)
        {
            skill.ObjectNumber += (int)change;
        }
        else
        {
            Debug.Log("SkillObjectNumber Can not bo less than 1");
            skill.ObjectNumber = 1;
        }
    }
    public override void MultiplFunction(ActiveSkills skill, float change)
    {
        Debug.Log("Can not Multiple ObjectNumbers");
    }
}
