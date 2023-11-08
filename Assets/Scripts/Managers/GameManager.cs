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
}
