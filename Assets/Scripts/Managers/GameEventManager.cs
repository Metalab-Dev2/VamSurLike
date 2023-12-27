using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameEventManager : MonoBehaviour
{

    public UnityEvent OnKeyMove;
    public static UnityEvent OnGameStart = new UnityEvent();
    public GameSceneManager sceneManager;
    public GameSceneInputManager inputManager;
    public UnityEvent InGame;
    private void Awake()
    {
        SetManagers();
        GetManagers();
        SetGameStart();
        OnGameStart.Invoke();
    }
    void Start()
    {
        InGameAddEvenet();
    }
    private void FixedUpdate()
    {
        if (OnKeyMove != null && inputManager.player!=null)
        {
            InGame.Invoke();
        }
    }
    private void SetManagers()
    {
        GameManager.instance.sceneManager = this.gameObject.transform.GetComponent<GameSceneManager>();
        GameManager.instance.inputManager = this.gameObject.transform.GetComponent<GameSceneInputManager>();
    }
    public void GetManagers()
    {
        inputManager = this.gameObject.GetComponent<GameSceneInputManager>();
        sceneManager = this.gameObject.GetComponent<GameSceneManager>();
        inputManager.gameManager = GameManager.instance;
        inputManager.sceneManager = sceneManager;
        sceneManager.gameManager = GameManager.instance;
        sceneManager.inputManager = inputManager;
        //SetGameStart();
    }
    private void SetGameStart()
    {
        OnGameStart.AddListener(sceneManager.AddEvent);
        OnGameStart.AddListener(inputManager.AddEvent);
    }
    private void InGameAddEvenet()
    {
        inputManager.player = GameManager.instance.playerOBJ;
        InGame.AddListener(sceneManager.GenerateMonster);
        InGame.AddListener(inputManager.MoveTo);
    }


}
