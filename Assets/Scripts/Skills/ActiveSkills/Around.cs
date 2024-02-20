using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Around : ActiveSkills
{

    public override void SetSkill()
    {
        skill_Script = this;
    }
    public override void SkillMove()
    {
        base.SkillMove();

        for (int i = 0; i < skillObject.Count; i++)
        {
            Vector2 temp;
            temp.x = skillObject[i].transform.position.x;
            temp.y = skillObject[i].transform.position.y;
            temp.x = temp.x * Mathf.Cos((360 * i / skillObject.Count) + Time.time);
            temp.y = temp.y * Mathf.Sin((360 * i / skillObject.Count) + Time.time);
            skillObject[i].transform.position = temp;
        }
    }
}
