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
        // ACtive Skill �ۼ��� GamaManager�� �߰��ϴ� �Լ�
        // Script�� NameSpace�� CSV�� Function ���� string�� ���ƾ���!
        // GameManager�� inGameSkillData�� Ŭ���� �̸����� ���� ������ �޶����� ��ųʸ��� �ҷ��� �� ����!
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
