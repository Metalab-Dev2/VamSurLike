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
    Button startButton;
    Button itemShopButton;
    Button upgradeButton;
    Button endButton;
    // Start is called before the first frame update
    void Start()
    {
        GetButtonObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetButtonObjects()
    {
        startButtonObj = GameObject.Find("StartButton ");
        itemShopButtonObj = GameObject.Find("ItemShopButton");
        upgradeButtonObj = GameObject.Find("UpgradeButton");
        endButtonObj = GameObject.Find("EndButton");
        startButton = startButtonObj.transform.GetComponent<Button>();
        itemShopButton = itemShopButtonObj.transform.GetComponent<Button>();
        upgradeButton = upgradeButtonObj.transform.GetComponent<Button>();
        endButton = endButtonObj.transform.GetComponent<Button>();
    }
    void SetButtonFunctions()
    {
        startButton.onClick.AddListener(OpenStageSelect);
        upgradeButton.onClick.AddListener(OpenItemShop);
        itemShopButton.onClick.AddListener(OpenItemShop);
        endButton.onClick.AddListener(OpenQuitUI);
    }
    public void OpenStageSelect()
    {

    }
    public void LoadGameScene()
    {
        GameManager.instance.LoadScene("GameScene");
    }
    public void OpenItemShop()
    {

    }
    public void OpenUpgrade()
    {

    }
    public void OpenQuitUI()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
