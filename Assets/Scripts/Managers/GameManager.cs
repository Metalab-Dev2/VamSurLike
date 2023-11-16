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
    public Dictionary<string, SkillBase> inGameSkillData = new Dictionary<string, SkillBase>();
    public List<Dictionary<string, object>> skillData = new List<Dictionary<string, object>>();
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
    }
    private void Update()
    {
        
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
}
