using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public Dictionary<string, ActiveSkills> activeSkillData = new Dictionary<string, ActiveSkills>();
    public Dictionary<string, FunctionBase> functions = new Dictionary<string, FunctionBase>();
    public List<Dictionary<string, object>> skillData = new List<Dictionary<string, object>>();
    // Start is called before the first frame update
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        

    }

    void Start()
    {
        ReadSkillData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReadSkillData()
    {
        string path = null;
        path = "DataCSV\\SkillData";
        skillData = CSVReader.Read(path);
        for (int i = 0; i < skillData.Count; i++)
        {
            string temp;
            temp = skillData[i]["skillName"].ToString();
            if (activeSkillData.ContainsKey(temp))
            {
                activeSkillData[temp]._BaseDamage = int.Parse(skillData[i]["BaseDamage"].ToString());
                activeSkillData[temp].index = int.Parse(skillData[i]["index"].ToString());
                activeSkillData[temp]._BaseAttackCycle = (float)(int.Parse(skillData[i]["attackCycle"].ToString()));
                activeSkillData[temp]._BaseAttackRange = float.Parse(skillData[i]["attackRange"].ToString());
                activeSkillData[temp]._BaseobjectSize = float.Parse(skillData[i]["objectSize"].ToString());
                activeSkillData[temp]._BaseObjectNumber = int.Parse(skillData[i]["objectNumber"].ToString());
                Debug.Log("ReadSuccec SkillName : " + temp);
            }
            else
            {
                Debug.Log("SkillNameError");
            }


        }
    }
    public void GetSkillData(string skillName)
    {

    }
}
