using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string sceneName;
    public GameObject sceneManager;
    public static GameManager instance;
    public List<EquipItemBase> items= new List<EquipItemBase>();
    
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
        
    }
    void GetSceneManager()
    {
        sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "StartScene":
                sceneManager = GameObject.Find("SartSceneManager");
                break;
            case "GameScene":
                break;
            default:
                break;
        }
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
