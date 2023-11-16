using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkills : SkillBase
{
    int _BaseDamage;
    int damage;
    int index;
    public float _BaseAttackCycle;
    public float attackCycle;
    public float _BaseAttackRange;
    public float attackRange;
    public float _BaseobjectSize;
    public float objectSize;
    protected SkillBase skill_Script;
    protected List<GameObject> skillObject;
    GameManager gameManager;
    public virtual void SkillMove()
    {
        
    }
    public virtual void InitiateSkill()
    {
        name = gameManager.skillData[index]["name"].ToString();
        _BaseAttackCycle = (float)gameManager.skillData[index]["BaseAttackCycle"];
        _BaseAttackRange = (float)gameManager.skillData[index]["BaseAttackRange"];
        _BaseDamage = (int)gameManager.skillData[index]["Damage"];
        Debug.Log("To do");
        Debug.Log("SetSkillData");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Monster")
        {
            return;
        }
        
    }
}
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

public class Around : ActiveSkills
{
    public override void SetSkill()
    {
        skill_Script = this;
    }
    public override void SkillMove()
    {
        base.SkillMove();

        for(int i = 0; i < skillObject.Count; i++)
        {
            Vector2 temp;
            temp.x = skillObject[i].transform.position.x;
            temp.y = skillObject[i].transform.position.y;
            temp.x = temp.x * Mathf.Cos((360 * i / skillObject.Count)+Time.time);
            temp.y = temp.y * Mathf.Sin((360 * i / skillObject.Count)+Time.time);
            skillObject[i].transform.position = temp;
        }
    }

}
