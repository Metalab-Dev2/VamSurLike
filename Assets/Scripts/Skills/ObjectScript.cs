using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    string skillName;
    SkillBase skill;
    public List<GameObject> skillObj = new List<GameObject>();
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.instance;
        skill = DataManager.instance.activeSkillData["Slash"];
    }
    private void Update()
    {
        if (skill is ActiveSkills activeSkill)
        {
            activeSkill.SkillMove();
        }
    }
    public void SetSkillScript()
    {
        if (gameManager == null)
        {
            gameManager = GameManager.instance;
        }
        skill = DataManager.instance.activeSkillData[skillName];
    }
}
