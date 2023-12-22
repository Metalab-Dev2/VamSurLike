using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSize : FunctionBase
{
    public override void AddFunction(ActiveSkills skill, float change)
    {
        if (skill.objectSize >= 0.2f)
        {
            skill.objectSize += (change);
        }
        else
        {
            Debug.Log("ObjectSize Can not be less than 0.2f");
            skill.objectSize = 0.2f;
        }
    }
    public override void MultiplFunction(ActiveSkills skill, float change)
    {
        if (skill.objectSize >= 0.2f)
        {
            skill.objectSize *= (1 + change);
        }
        else
        {
            Debug.Log("Object Size Can not be less than 0.2f");
            skill.objectSize = 0.2f;
        }
    }
}
