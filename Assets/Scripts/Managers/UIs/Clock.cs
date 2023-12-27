using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Clock : MonoBehaviour
{
    string time;
    TextMeshProUGUI myTMP;
    void Start()
    {
        myTMP = this.gameObject.transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        myTMP.text = Time.time.ToString("0.00");
    }
}
