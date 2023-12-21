using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string sceneName;
    public int stage;
    public int maxStage=2;
    public GameObject sceneManagerOBJ;
    public GameObject playerOBJ;
    public static GameManager instance;
    public InputManagerBase inputManager;
    public SceneManagerBase sceneManager;
    public List<EquipItemBase> items= new List<EquipItemBase>();
    public Dictionary<string, ActiveSkills> activeSkillData = new Dictionary<string, ActiveSkills>();
    public List<Dictionary<string, object>> skillData = new List<Dictionary<string, object>>();
    public int test;
    private void Awake()
    {
        if (GameManager.instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Test();
        ReadSkillData();
    }
    private void Update()
    {
        //test = inGameSkillData.Count;
        //Debug.Log(inGameSkillData["Slash"].skillName);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);

    }
    public void Test()
    {
        if(sceneManager is StartSceneManager)
        {
            Debug.Log(sceneManager.openUI.Count);
        }
    }


    public void ReadSkillData()
    {
        string path = null;
        path = "DataCSV\\SkillData";
        skillData = CSVReader.Read(path);
        for(int i =0; i < skillData.Count; i++)
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
                Debug.Log("ReadSuccec SkillName : "+temp);
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

    /*
    public void InGameSkillDataInitialize()
    {
        AddSkillToDictionary("Slash", CreateSkill<Slash>());
        AddSkillToDictionary("Around", CreateSkill<Around>());
        //스킬 추가 후 이곳에서 데이터 추가
    }
    
    public T CreateSkill<T>() where T:SkillBase,new()
    {
        T skill = new T();
        skill.SkillInitialize();
        return skill;
    }
    public void AddSkillToDictionary(string key,SkillBase skill)
    {
        
        if (!inGameSkillData.ContainsKey(key))
        {
            inGameSkillData.Add(key, skill);
        }
    }
    */
}
