using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartSceneManager : MonoBehaviour
{
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
    public List<GameObject> openUI = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SetObjects();
        SetButtonFunctions();
        ActiveFalsePanels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
    void ActiveFalsePanels()
    {
        shopPanel.SetActive(false);
        upgragePanel.SetActive(false);
        QuitPanel.SetActive(false);
        stageSelectPanel.SetActive(false);
    }
    void ObjectActiveChange(GameObject go)
    {
        if (go.activeSelf)
        {
            go.SetActive(false);
            Debug.Log(go.name);
            openUI.Remove(go);
        }
        else if (!go.activeSelf)
        {
            go.SetActive(true);
            openUI.Add(go);
        }  
    }
    public void OpenStageSelect()
    {
        ObjectActiveChange(stageSelectPanel);
    }
    public void LoadGameScene()
    {
        GameManager.instance.LoadScene("GameScene");
    }
    public void OpenItemShop()
    {
        ObjectActiveChange(shopPanel);
    }
    public void OpenUpgrade()
    {
        ObjectActiveChange(upgragePanel);
    }
    public void OpenQuitUI()
    {
        ObjectActiveChange(QuitPanel);
    }
    public void CancleQuit()
    {
        ObjectActiveChange(QuitPanel);
        Debug.Log(11);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
