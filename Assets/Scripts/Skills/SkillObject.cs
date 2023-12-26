using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObject : MonoBehaviour
{
    public List<GameObject> skillObjects = new List<GameObject>();
    public ActiveSkills mySkill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mySkill != null)
        {
            mySkill.SkillMove();
        }
        
    }
}
