using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string sceneName;
    public GameObject sceneManagerOBJ;
    public static GameManager instance;
    public InputManagerBase inputManager;
    public SceneManagerBase sceneManager;
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
        GetSceneManager();
        Test();
    }
    private void Update()
    {
        
    }
    void GetSceneManager()
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
}
