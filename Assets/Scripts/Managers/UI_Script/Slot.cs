using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public EquipItemBase item;
    public Sprite slotSprite;


    private void Start()
    {
        slotSprite = this.gameObject.transform.GetComponent<Image>().sprite;
    }

    private void OnEnable()
    {
        
    }


    void SetSprite()
    {
        string path = "Items\\" + item.itemName;
        slotSprite = Resources.Load<Sprite>(path);
        transform.GetComponent<Image>().sprite = slotSprite;
    }


}
