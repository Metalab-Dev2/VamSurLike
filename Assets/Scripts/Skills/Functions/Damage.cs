using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : FunctionBase
{
    public override void AddFunction(ActiveSkills skill, float change)
    {
        if (skill.damage > 1)
        {
            skill.damage += (int)change;
        }
        else
        {
            Debug.Log("SkillDamage Can not be less than 1");
            skill.damage = 1;
        }
        
    }
    public override void MultiplFunction(ActiveSkills skill, float change)
    {
        if (skill.damage > 1)
        {
            skill.damage *= (int)(1 + change);
        }
        else
        {
            Debug.Log("SkillDamage Can not be less than 1");
            skill.damage = 1;
        }
    }

}
