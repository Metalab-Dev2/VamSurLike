using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ActiveSkills : SkillBase
{

    public int _BaseDamage;
    public int damage;
    public int index;
    public int level;
    public int _BaseObjectNumber;
    public int ObjectNumber;

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
    public void AddDictionary()
    {
        // ACtive Skill 작성시 GamaManager에 추가하는 함수
        // Script의 NameSpace와 CSV의 Function 란의 string값 같아야함!
        // GameManager의 inGameSkillData에 클래스 이름으로 들어가기 때문에 달라지면 딕셔너리로 불러올 수 없음!
        gameManager = GameManager.instance;
        skillName = this.GetType().Name;
        if (skillName == "ActiveSkills")
        {
            return;
        }
        if (!DataManager.instance.activeSkillData.ContainsKey(skillName))
        {
            DataManager.instance.activeSkillData.Add(skillName, this);
        }

        Debug.Log("To do    //  ActiveSkills Script");
        Debug.Log("SetSkillData");
        Debug.Log(skillName);
    }
    private void Start()
    {
        AddDictionary();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Monster")
        {
            return;
        }

    }
}
