using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameSceneManager : SceneManagerBase,IPlayerProvider
{
    public GameObject player { get; set; }
    public GameObject tileMapPrefab;
    public GameObject grid;
    public GameObject monsterPrefab;
    public GameObject playerPrefab;
    //public GameObject playerObj;
    [SerializeField] Vector2 playerPos;
    PlayerState playerState;
    
    float minPos = 1;
    float maxPos = 5;
    public float lastGenTime;
    public float genTime = 1f;
    int playerLevel;

    GameObject Canvas;
    public GameObject levelUpPanel;
    public GameObject skillUpPanel;
    public GameObject infoPanel;
    //List<GameObject> openUI;
    List<Button> skillUpButton = new List<Button>();
    List<GameObject> skillUpButtonObject = new List<GameObject>();
    private void Start()
    {
        genTime = 1f;
        playerState = player.transform.GetComponent<PlayerState>();
        SetUIObjects();
    }
    #region InitiateGame
    public override SceneManagerBase ReturnType()
    {
        return this;
    }

    public override void AddEvent()
    {
        SetPlayer();
    }
    void SetPlayer()
    {
        if (GameManager.instance.playerOBJ == null)
        {
            player = Instantiate(playerPrefab, new Vector3(0, 0, -1), Quaternion.identity);
            GameManager.instance.playerOBJ = player;
            GameManager.instance.playerState = player.transform.GetComponent<PlayerState>();
            SetInputManager();
            if (inputManager is IPlayerProvider playerProvider)
            {
                playerProvider.player = GameManager.instance.playerOBJ;
                //inputManager.player = GameManager.instance.playerOBJ;
                //inputManager.player = playerObj;
            }
        }
    }
    public void GenerateTileMap(Vector2 mapCenterPos)
    {
        Vector2 targetPos = new Vector2();
        Vector2 colSize = new Vector2() { x = 1, y = 1 };
        for (int y = -1; y < 2; y++)
        {
            for (int x = -1; x < 2; x++)
            {
                targetPos.x = mapCenterPos.x + x * 26;
                targetPos.y = mapCenterPos.y + y * 16;
                Collider2D col = Physics2D.OverlapBox(targetPos, colSize, 0);
                if (col != null)
                    continue;

                GameObject go = Instantiate(tileMapPrefab, targetPos, Quaternion.identity);
                go.transform.SetParent(grid.transform);
                //TileMapBake(go);

            }
        }
        Debug.Log("MapGenerate");
    }


    public void GenerateMonster()
    {

        if (Time.time >= lastGenTime + genTime)
        {
            Vector2 temp = SetRandomPos();
            GameObject go = Instantiate(monsterPrefab, new Vector3(temp.x, temp.y, -1), Quaternion.identity);
            lastGenTime = Time.time;
        }
    }

    public Vector2 SetRandomPos()
    {
        Vector2 randomPos = Vector2.zero;
        playerPos = player.transform.position;
        int angle = Random.Range(0, 360);
        float temp = Random.Range(minPos, maxPos);
        randomPos.x = playerPos.x + (temp * Mathf.Cos(angle));
        randomPos.y = playerPos.y + (temp * Mathf.Sin(angle));
        return randomPos;
    }

    protected override void SetInputManager()
    {
        if (GameManager.instance.inputManager is GameSceneInputManager)
        {
            inputManager = (GameSceneInputManager)GameManager.instance.inputManager;
        }

    }
    #endregion
    #region ButtonSet
    public void SetUIObjects()
    {
        Canvas = GameObject.Find("Canvas");
        levelUpPanel = Canvas.transform.GetChild(0).gameObject;
        infoPanel = Canvas.transform.GetChild(0).transform.GetChild(0).gameObject;
        skillUpPanel = Canvas.transform.GetChild(0).transform.GetChild(1).gameObject;
        for(int i = 0; i < skillUpPanel.transform.childCount; i++)
        {
            skillUpButton.Add(skillUpPanel.transform.GetChild(i).transform.GetChild(0).GetComponent<Button>());
            Debug.Log(skillUpPanel.transform.GetChild(i).name);
            skillUpButtonObject.Add(skillUpPanel.transform.GetChild(i).gameObject);
        }
        for(int i = 0; i < skillUpButton.Count; i++)
        {
            Debug.Log("ButtonCount : "+skillUpButton.Count);
            Debug.Log(skillUpButton[i]);
            skillUpButton[i].onClick.AddListener(SkillUpButtonAction);
        }
    }
    
    public void SkillUpButtonAction()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale =1;
    }
    #endregion
    #region LevelUp
    public void SkillNameSet()
    {
        if (false)
        {
            Debug.Log("Chnage To Users SkillNumbers");
        }

        else
        {
            List<string> skillNames = new List<string>(DataManager.instance.activeSkillData.Keys);
            for (int i = 0; i < skillUpButton.Count; i++)
            {
                if (skillNames.Count > 0)
                {
                    int temp = Random.Range(0, skillNames.Count);
                    skillUpButton[i].transform.GetComponent<SkillUpButton>().skillName = skillNames[temp];
                    skillNames.RemoveAt(temp);
                }
            }
        }
    }
    public void UserLevelUp()
    {
        Time.timeScale = 0;
        SkillNameSet();
        levelUpPanel.SetActive(true);
    }
    public void ButtonSkillSet()
    {

    }

    public void SkillUpButtonIconSet()
    {

    }
    #endregion
}
