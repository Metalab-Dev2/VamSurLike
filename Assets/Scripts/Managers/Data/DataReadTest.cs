using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReadTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //DataRead();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void DataRead()
    {
        string path = null;
        path = "DataCSV\\SkillData";
        List<Dictionary<string, object>> Data;
        Data = CSVReader.Read(path);
        for(int i = 0; i < Data.Count; i++)
        {
            Debug.Log(Data[i]["index"].ToString());
            Debug.Log(Data[i]["skillName"].ToString());
        }


    }
}
