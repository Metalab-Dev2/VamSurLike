using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject playerObj;

    
    // Update is called once per frame
    void Update()
    {
        CameraFollw();
    }
    void CameraFollw()
    {
        if(playerObj == null)
        {
            playerObj = GameManager.instance.playerOBJ;
        }
        if (playerObj != null)
        {
            this.gameObject.transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, -10);
        }
    }
}
