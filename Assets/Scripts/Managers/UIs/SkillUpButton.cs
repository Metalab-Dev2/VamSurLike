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

    private void OnEnable()
    {

        buttonObj.transform.GetComponent<Button>().onClick.AddListener(SetButtonFunction);
    }

    private void OnDisable()
    {
        skillData.Clear();
        functions.Clear();
    }
}
