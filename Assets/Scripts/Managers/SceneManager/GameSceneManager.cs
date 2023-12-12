using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : SceneManagerBase
{
    GameSceneInputManager inputManager;
    public GameObject tileMapPrefab;
    public GameObject grid;
    public GameObject monsterPrefab;
    public GameObject playerPrefab;
    public GameObject playerObj;
    [SerializeField] Vector2 playerPos;
    float minPos = 5;
    float maxPos = 10;
    public float lastGenTime;
    public float genTime = 1f;

    private void Start()
    {
        genTime = 1f;
    }
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
            playerObj = Instantiate(playerPrefab, new Vector3(0, 0, -1), Quaternion.identity);
            GameManager.instance.playerOBJ = playerObj;
            SetInputManager();
            if (inputManager is GameSceneInputManager)
            {
                inputManager.player = GameManager.instance.playerOBJ;
                inputManager.player = playerObj;
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
        playerPos = playerObj.transform.position;
        int temp = Random.Range(-1, 2);
        randomPos.x = playerPos.x + temp * (Random.Range(minPos, maxPos));
        temp = Random.Range(-1, 2);
        randomPos.y = playerPos.y + temp * (Random.Range(minPos, maxPos));
        return randomPos;
    }

    protected override void SetInputManager()
    {
        if (GameManager.instance.inputManager is GameSceneInputManager)
        {
            inputManager = (GameSceneInputManager)GameManager.instance.inputManager;
        }

    }
}
