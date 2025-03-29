using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider;
    public float maxHP = 10;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        slider.value = Player.instance.HP / maxHP;
    }
}
