using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
public class GenerateMap : MonoBehaviour
{
    GameSceneManager gameSceneManager;
    // Start is called before the first frame update
    
    void Start()
    {
        if(GameManager.instance.sceneManager is GameSceneManager&& gameSceneManager==null)
        {
            gameSceneManager = (GameSceneManager)GameManager.instance.sceneManager;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (gameSceneManager == null)
                gameSceneManager = (GameSceneManager)GameManager.instance.sceneManager;

            gameSceneManager.GenerateTileMap(this.gameObject.transform.position);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (gameSceneManager == null)
                gameSceneManager = (GameSceneManager)GameManager.instance.sceneManager;

            gameSceneManager.GenerateTileMap(this.gameObject.transform.position);
        }
    }
}
