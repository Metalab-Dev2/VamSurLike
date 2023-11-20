using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : ActiveSkills
{
    
    public override void SetSkill()
    {
        skill_Script = this;
    }
    public override void SetSkillObject()
    {
        front.x += attackRange;
        front.y += attackRange;
        this.gameObject.transform.position = front;
    }
}
