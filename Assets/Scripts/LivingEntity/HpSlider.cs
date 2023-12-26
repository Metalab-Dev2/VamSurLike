using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpSlider : MonoBehaviour
{
    LivingEntity myEntity;
    Slider hpSlider;
    GameObject myCanvas;
    int maxHp;
    int currentHp;
    private void Start()
    {
        myCanvas = transform.GetChild(0).gameObject;
        myEntity = transform.GetComponent<LivingEntity>();
        hpSlider = myCanvas.transform.GetChild(0).transform.GetComponent<Slider>();
    }

    private void Update()
    {
        ChangeSliderValue();
    }

    void ChangeSliderValue()
    {
        if (myEntity.currentHp != currentHp && hpSlider!=null)
        {
            hpSlider.value = myEntity.currentHp / myEntity.maxHp;
            currentHp = myEntity.currentHp;
        }
        
    }

}
