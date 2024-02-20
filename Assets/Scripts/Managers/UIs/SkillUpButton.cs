using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillUpButton : MonoBehaviour
{
    public string skillName;
    GameObject buttonObj;
    Image skillIcon;
    TextMeshPro skillNameText;
    TextMeshPro skillDiscriptionText;
    List<Dictionary<string, object>> skillData;
    PlayerState playerState;
    int skillLevel;
    List<string> functions;
    private void Start()
    {
        buttonObj = this.gameObject.transform.GetChild(0).gameObject;
        skillIcon = buttonObj.transform.GetChild(0).transform.GetComponent<Image>();
        skillNameText = buttonObj.transform.GetChild(1).transform.GetComponent<TextMeshPro>();
        skillDiscriptionText = buttonObj.transform.GetChild(2).transform.GetComponent<TextMeshPro>();
        playerState = GameManager.instance.playerState;
    }

    void SetButtonFunction()
    {
        for(int i = 0; i < functions.Count; i++)
        {
            string separateString=null;
            Separate(separateString);
        }
        //GameManager.instance.playerState.skillObjects[skillName]
    }

    void Separate(string saparateString)
    {
        switch (saparateString)
        {

            case "Add":
                break;
            case "Multi":
                break;
            default:
                Debug.Log("SaparateError");
                break;
        }
    }
    void InitiateButton()
    {
        SetSkillData();
        SetIcon();
        SetNameText();
        SetDiscription();
    }
    void SetSkillData()
    {
        string path = "DataCSV\\"+skillName;
        skillData = CSVReader.Read(path);
    }

    void SetIcon()
    {
        string path = "SkillIcons\\" + skillName;
        skillIcon.sprite = Resources.Load<Sprite>(path);
    }

    void SetNameText()
    {
        skillLevel = GameManager.instance.playerOBJ.transform.GetComponent<PlayerState>().skills[skillName].level;
        skillNameText.text = skillName+" Lv : "+ skillLevel+1;
    }

    void SetDiscription()
    {
        string key = "Discription" + GameManager.instance.language;
        if (playerState.skills.ContainsKey(skillName))
        {
            int skillLevel = playerState.skills[skillName].level;
            skillDiscriptionText.text = skillData[skillLevel][key].ToString();
        }
        else
        {
            skillDiscriptionText.text = skillData[0][key].ToString();
        }
    }
    void SetFunctions()
    {
        string path = "DataCSV\\" + skillName;
        string functions = skillData[skillLevel]["function"].ToString();
        //저장한 펑션 특정 문자로 나눈 후 functionManager에서 function 함수를 가져올 필요 있음
    }
    private void OnEnable()
    {
        //buttonObj.transform.GetComponent<Button>().onClick.AddListener(SetButtonFunction);
    }

    private void OnDisable()
    {
        if (skillData.Count >= 1)
        {
            skillData.Clear();
        }
        if (functions.Count >= 1)
        {
            functions.Clear();
        }
        
    }
}
