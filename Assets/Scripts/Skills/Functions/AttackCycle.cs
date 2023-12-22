using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCycle : FunctionBase
{
    public override void AddFunction(ActiveSkills skill, float change)
    {
        if ((skill.attackCycle - change) >= 0.2)
        {
            skill.attackCycle -= change;
        }
        else
        {
            Debug.Log("AttackCycle Can not be less than 0.2s");
            skill.attackCycle = 0.2f;
        }

    }
    public override void MultiplFunction(ActiveSkills skill, float change)
    {
        skill.damage *= (int)(1 + change);

        if (skill.attackCycle * (1 - change) >= 0.2)
        {
            skill.attackCycle *= (1 - change);
        }
        else
        {
            Debug.Log("AttackCycle Can not be less than 0.2s");
            skill.attackCycle = 0.2f;
        }
    }
}
