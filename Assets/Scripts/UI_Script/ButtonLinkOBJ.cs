using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLinkOBJ : MonoBehaviour
{
    public GameObject linkedUIObj;
    void ActiveChangeOBJ()
    {
        if (linkedUIObj.activeSelf)
        {
            linkedUIObj.SetActive(false);
        }
        else if (!linkedUIObj.activeSelf)
        {
            linkedUIObj.SetActive(true);
        }
    }
}
