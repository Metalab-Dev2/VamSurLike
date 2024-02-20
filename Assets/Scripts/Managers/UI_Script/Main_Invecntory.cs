using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Invecntory : MonoBehaviour
{
    public List<EquipItemBase> items = new List<EquipItemBase>();
    public GameObject itemSlots;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }
    private void OnEnable()
    {
        if(gameManager != null&&gameManager.items.Count>0 )
            items = gameManager.items;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void GetInventoryItems()
    {
        for(int i = 0; i < items.Count; i++)
        {
            GameObject go = Instantiate(itemSlots);
            go.transform.SetParent(this.gameObject.transform);
            go.transform.GetComponent<Slot>().item = this.items[i];
        }
    }
    void AddItemData(EquipItemBase itemData)
    {
        items.Add(itemData);
        
    }
    void RemoveItemData(EquipItemBase itemData)
    {
        if (items.Contains(itemData))
        {
            items.Remove(itemData);
        }
    }
}
