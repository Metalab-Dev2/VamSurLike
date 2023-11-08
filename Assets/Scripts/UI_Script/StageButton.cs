using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int childNumber;

    public void SetStageNumber()
    {
        GameManager.instance.stage = childNumber;
        SceneManager.LoadScene("GameScene");
        Debug.Log(11);
    }
}
