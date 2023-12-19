using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NaviScript : MonoBehaviour
{
    NavMeshAgent myNavi;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        myNavi = transform.GetComponent<NavMeshAgent>();
        player = GameManager.instance.playerOBJ;
    }

    // Update is called once per frame
    void Update()
    {
        myNavi.SetDestination(player.transform.position);
    }
}
