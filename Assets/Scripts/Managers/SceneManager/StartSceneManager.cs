using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartSceneManager : SceneManagerBase
{

    public GameObject stageButtonPrefab;
    
    GameObject startButtonObj;
    GameObject itemShopButtonObj;
    GameObject upgradeButtonObj;
    GameObject endButtonObj;
    GameObject yesButtonObj;
    GameObject noButtonObj;

    GameObject shopPanel;
    GameObject stageSelectPanel;
    GameObject QuitPanel;
    GameObject upgragePanel;

    Button startButton;
    Button itemShopButton;
    Button upgradeButton;
    Button endButton;
    


    void Start()
    {
        SetGameManager();
        SetObjects();
        SetButtonFunctions();
        ActiveFalsePanels();
        SetStageNumber();
        if (gameManager != null)
            gameManager.sceneManager = ReturnType();
        else
        {
            gameManager = GameManager.instance;
            gameManager.sceneManager = ReturnType();
        }
    }

    void Update()
    {
        
    }

    protected override void SetSceneManager()
    {
        gameManager.sceneManager = this;
    }

    public override SceneManagerBase ReturnType()
    {
        return this;
    }
    #region ObjectSetting
    void SetObjects()
    {
        startButtonObj = GameObject.Find("StartButton ");
        itemShopButtonObj = GameObject.Find("ItemShopButton");
        upgradeButtonObj = GameObject.Find("UpgradeButton");
        endButtonObj = GameObject.Find("EndButton");
        startButton = startButtonObj.transform.GetComponent<Button>();
        itemShopButton = itemShopButtonObj.transform.GetComponent<Button>();
        upgradeButton = upgradeButtonObj.transform.GetComponent<Button>();
        endButton = endButtonObj.transform.GetComponent<Button>();

        shopPanel = GameObject.Find("ShopPanel");
        stageSelectPanel = GameObject.Find("StageSelectPanel");
        QuitPanel = GameObject.Find("QuitPanel");
        yesButtonObj = QuitPanel.transform.GetChild(0).gameObject;
        noButtonObj = QuitPanel.transform.GetChild(1).gameObject;
        upgragePanel = GameObject.Find("UpgradePanel");
    }

    void SetButtonFunctions()
    {
        startButton.onClick.AddListener(OpenStageSelect);
        upgradeButton.onClick.AddListener(OpenUpgrade);
        itemShopButton.onClick.AddListener(OpenItemShop);
        endButton.onClick.AddListener(OpenQuitUI);
        yesButtonObj.transform.GetComponent<Button>().onClick.AddListener(QuitGame);
        noButtonObj.transform.GetComponent<Button>().onClick.AddListener(CancleQuit);
    }
    #endregion

    void ActiveFalsePanels()
    {
        shopPanel.SetActive(false);
        upgragePanel.SetActive(false);
        QuitPanel.SetActive(false);
        stageSelectPanel.SetActive(false);
    }
    /*
    public void UISetActiveChange(GameObject go)
    {
        GameObject LinkedGO = go.transform.GetComponent<ButtonLinkOBJ>().linkedUIObj;
        ChangeUIActive(LinkedGO);
    }
    */
    #region ButtonFunction
    public void OpenStageSelect()
    {
        ChangeUIActive(stageSelectPanel);
    }
    public void LoadGameScene()
    {
        GameManager.instance.LoadScene("GameScene");
    }
    public void OpenItemShop()
    {
        ChangeUIActive(shopPanel);
    }

    public void OpenUpgrade()
    {
        ChangeUIActive(upgragePanel);
    }

    public void OpenQuitUI()
    {
        ChangeUIActive(QuitPanel);
    }

    public void CancleQuit()
    {
        ChangeUIActive(QuitPanel);
        Debug.Log(11);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StageButton(int SceneNumber)
    {
        gameManager.stage = SceneNumber;
        SceneManager.LoadScene("GameScene");
    }
    #endregion

    public void SetStageNumber()
    {
        for(int i = 0; i < gameManager.maxStage; i++)
        {
            GameObject go = Instantiate(stageButtonPrefab);
            go.transform.SetParent(stageSelectPanel.transform);
            go.transform.GetComponent<StageButton>().childNumber = i;
            go.transform.GetComponent<Button>().onClick.AddListener(go.transform.GetComponent<StageButton>().SetStageNumber);
            go.transform.localScale = Vector3.one;
            
        }
    }
    
    
}
