using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : SceneManagerBase
{
    public GameObject tileMapPrefab;
    public GameObject grid;

    public override SceneManagerBase ReturnType()
    {
        return this;
    }
    protected override void SetSceneManager()
    {
        if (gameManager == null)
            gameManager = GameManager.instance;
        gameManager.sceneManager = ReturnType();
        Debug.Log("GameSceneManager");
    }
    // Start is called before the first frame update
    void Start()
    {
        SetGameManager();
        SetSceneManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GenerateTileMap(Vector2 mapCenterPos)
    {
        Vector2 targetPos = new Vector2();
        Vector2 colSize = new Vector2() { x=1,y=1};
        for(int y = -1; y < 2; y++)
        {
            for(int x = -1; x < 2; x++)
            {
                targetPos.x = mapCenterPos.x + x * 26;
                targetPos.y = mapCenterPos.y + y * 16;
                Collider2D col = Physics2D.OverlapBox(targetPos,colSize,0);
                if (col != null)
                    continue;

                GameObject go = Instantiate(tileMapPrefab,targetPos,Quaternion.identity);
                go.transform.SetParent(grid.transform);

            }
        }
        Debug.Log("MapGenerate");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
